
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Service.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolProject.Service.implementaion
{
    public class AuthenticationService(JwtSettings jwtSettings) : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings;

        public async Task<string> GetTWTToken(User user)
        {
            var claims = new List<Claim>
            {
                new(nameof( UserClaimModel.UserName),user.UserName),
                new (nameof( UserClaimModel.Email),user.Email),
                new(nameof( UserClaimModel.PhoneNumber),user.PhoneNumber)
            };
            var jwttoken = new JwtSecurityToken
            (_jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accesstoken = new JwtSecurityTokenHandler().WriteToken(jwttoken);
            return accesstoken;
        }
    }
}
