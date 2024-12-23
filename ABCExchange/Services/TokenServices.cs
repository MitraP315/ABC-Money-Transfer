

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity;
using ABCExchange.Models;
namespace ABCExchange.Services
{
    
    public class TokenService
    {
        private readonly string _secretKey;
        private readonly string _refreshSecretKey;

        public TokenService(IConfiguration configuration)
        {
            // Accessing values from appsettings.json
            _secretKey = configuration["JwtSettings:SecretKey"];
            _refreshSecretKey = configuration["JwtSettings:RefreshSecretKey"];
        }

        public (string AccessToken, string RefreshToken) GenerateTokens(AppUser user, IList<string> roles)
        {
            var accessToken = GenerateAccessToken(user,roles);
            var refreshToken = GenerateRefreshToken(user,roles);

            return (AccessToken: accessToken, RefreshToken: refreshToken);
        }

        private string GenerateAccessToken(AppUser user, IList<string> roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: "ABSExchange",
                audience: "ABSExchange",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5), // Access token expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken(AppUser user, IList<string> roles)
        {
            var refreshKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_refreshSecretKey));
            var credentials = new SigningCredentials(refreshKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var token = new JwtSecurityToken(
                issuer: "ABSExchange",
                audience: "ABSExchange",
                claims: claims,
                expires: DateTime.Now.AddDays(7), // Refresh token expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

     
    }

}
