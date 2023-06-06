using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using SolarCoffe.Data.Models.Auth;

namespace SolarCoffe.Service.Session
{
    public class JwtTokenGenerator : IJWT
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials
               (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
               SecurityAlgorithms.HmacSha256);


            var claims = new[]
       {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),

            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(6),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
