using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class AuthenticationService(JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepository, UserManager<User> userManager) : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
        private readonly UserManager<User> _userManager = userManager;

        public async Task<JwtAuthRespone> GetJWTToken(User user)
        {

            var jwttoken = GenerateJwtToken(user);
            var refreshtoken = GetRefrechToken(user.UserName);
            var saverefreshtoken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsUsed = false,
                JwtId = jwttoken.Item3,
                RefreshToken = refreshtoken.RefreshTokenstring,
                Token = jwttoken.Item2,
                UserId = user.Id,
                user = user,
                IsRevoked = false
            };
            await _refreshTokenRepository.AddAsync(saverefreshtoken);
            return new JwtAuthRespone
            {
                AccessToken = jwttoken.Item2,
                RefreshToken = refreshtoken

            };
        }
        private RefreshToken GetRefrechToken(string username)
        {
            var refreshtoken = new RefreshToken
            {
                RefreshTokenstring = GenerateRefrechTokenString(),
                UserName = username,
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate)
            };
            return refreshtoken;
        }
        private string GenerateRefrechTokenString()
        {
            var rondomnum = new byte[32];
            var rondomnumgenerate = RandomNumberGenerator.Create();
            rondomnumgenerate.GetBytes(rondomnum);
            return Convert.ToBase64String(rondomnum);
        }
        private List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new(nameof (UserClaimModel.UserName),user.UserName),
                new (nameof( UserClaimModel.Email),user.Email),
                new(nameof( UserClaimModel.PhoneNumber),user.PhoneNumber),
                new (nameof(UserClaimModel.Id),user.Id.ToString())
            };
            return claims;
        }
        private JwtSecurityToken ReadToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;
        }
        private (JwtSecurityToken, string, string) GenerateJwtToken(User user)
        {
            var jti = Guid.NewGuid().ToString(); // ← generate JWT ID
            var claims = GetClaims(user);

            var jwttoken = new JwtSecurityToken
            (_jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpireDate),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accesstoken = new JwtSecurityTokenHandler().WriteToken(jwttoken);
            return (jwttoken, accesstoken, jti);
        }

        public async Task<JwtAuthRespone> GetRefrechToken(string accessToken, string refreshToken)
        {
            //Read token to get claims
            var jwttoken = ReadToken(accessToken);
            if (jwttoken is null || !jwttoken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature)) throw new SecurityTokenException("jwttoken or Algorithm is wrong");

            if (jwttoken.ValidTo > DateTime.UtcNow) throw new SecurityTokenException("jwttoken is not Expired");

            var userid = jwttoken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.Id)).Value;
            //chech refreshtoken is found or not 
            var savedRefreshToken = await _refreshTokenRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.RefreshToken == refreshToken && x.UserId == int.Parse(userid));// Error
            if (savedRefreshToken.ExpiryDate < DateTime.UtcNow || savedRefreshToken is null || savedRefreshToken.IsUsed || savedRefreshToken.IsRevoked)
                throw new SecurityTokenException("Refreshtoken غير صالح");
            //for Securety check if JWTid is Good 
            if (savedRefreshToken.JwtId == jwttoken.Id)
            {
                throw new SecurityTokenException("التوكن لا يتطابق");
            }
            savedRefreshToken.IsUsed = true;
            await _refreshTokenRepository.UpdateAsync(savedRefreshToken);
            //create new token
            var ActialUser = await _userManager.FindByIdAsync(userid);
            var response = GetJWTToken(ActialUser);
            return await response;
        }


        public TokenValidatedResult ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuer = _jwtSettings.Issuer,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidAudience = _jwtSettings.Audience,
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
                ClockSkew = TimeSpan.Zero // لمنع تأخير الثواني
            };

            try
            {
                var principal = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);
                return new TokenValidatedResult
                {
                    IsValid = true,
                    IsExpired = false,
                    Message = "Token is valid",
                    Principal = principal
                };
            }
            catch (Exception ex) when (ex is SecurityTokenExpiredException || ex is SecurityTokenException || ex is Exception)
            {
                return ex switch
                {
                    SecurityTokenExpiredException _ => new TokenValidatedResult
                    {
                        IsValid = false,
                        IsExpired = true,
                        Message = "Token has expired"
                    },
                    SecurityTokenException _ => new TokenValidatedResult
                    {
                        IsValid = false,
                        IsExpired = false,
                        Message = $"Invalid token: {ex.Message}"
                    },
                    _ => new TokenValidatedResult
                    {
                        IsValid = false,
                        IsExpired = false,
                        Message = $"Unexpected error: {ex.Message}"
                    }
                };
            }

        }
    }
}
