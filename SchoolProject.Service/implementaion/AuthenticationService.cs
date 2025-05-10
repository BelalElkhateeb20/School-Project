using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.Service.Abstracts;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace SchoolProject.Service.implementaion
{
    public class AuthenticationService(JwtSettings jwtSettings,IRefreshTokenRepository refreshTokenRepository) : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

        public async Task <JwtAuthRespone> GetJWTToken(User user)
        {

            var jwttoken= GenerateTwtToken(user);
            var refreshtoken = GetRefrechToken(user.UserName);
            var saverefreshtoken = new UserRefreshToken
            {
                AddedTime=DateTime.Now,
                ExpiryDate= DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsUsed=false,
                JwtId= jwttoken.Item1.Id,
                RefreshToken=refreshtoken.RefreshTokenstring,
                Token= jwttoken.Item2,
                UserId=user.Id,
                user=user,
                IsRevoked=false
            };
            await _refreshTokenRepository.AddAsync(saverefreshtoken);
            return new JwtAuthRespone
            {
                AccessToken = jwttoken.Item2,
                RefreshToken= refreshtoken

            };
        }
        private  RefreshToken GetRefrechToken(string username)
        {
            var refreshtoken = new RefreshToken
            {
                RefreshTokenstring = GenerateRefrechTokenString(),
                UserName = username,
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate)
            };
            return refreshtoken;
        }
        private  string GenerateRefrechTokenString()
        {
            var rondomnum = new byte[32];
            var rondomnumgenerate = RandomNumberGenerator.Create();
            rondomnumgenerate.GetBytes(rondomnum);
            return Convert.ToBase64String(rondomnum);
        }
        private  List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new(nameof (UserClaimModel.UserName),user.UserName),
                new (nameof( UserClaimModel.Email),user.Email),
                new(nameof( UserClaimModel.PhoneNumber),user.PhoneNumber)
            };
            return claims;
        }
        private  (JwtSecurityToken,string) GenerateTwtToken(User user)
        {
            var claims = GetClaims(user);

            var jwttoken = new JwtSecurityToken
            (_jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpireDate),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accesstoken = new JwtSecurityTokenHandler().WriteToken(jwttoken);
            return (jwttoken, accesstoken);
        }
    }
}
