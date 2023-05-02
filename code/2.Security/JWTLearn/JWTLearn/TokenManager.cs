using JWTLearn.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTLearn
{
    public class TokenManager
    {
        public static string GenerateToken(User user)
        {
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtSecret"]);
            var secretKey = new SymmetricSecurityKey(secretKeyBytes);
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("password", user.Password),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var tokenOptions = new JwtSecurityToken(
                issuer: ConfigurationManager.AppSettings["JwtIssuer"],
                audience: ConfigurationManager.AppSettings["JwtAudience"],
                claims: claims,
                signingCredentials: signinCredentials,
                expires: DateTime.Now.AddMinutes(40)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
        public static bool ValidateToken(string token)
        {
            var secretKeyBytes = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtSecret"]);
            var secretKey = new SymmetricSecurityKey(secretKeyBytes);

            var validationParameter = new TokenValidationParameters()
            {
                IssuerSigningKey = secretKey,
                ValidIssuer = ConfigurationManager.AppSettings["JwtIssuer"],
                ValidAudience = ConfigurationManager.AppSettings["JwtAudience"],
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                SecurityToken securityToken;
                tokenHandler.ValidateToken(token, validationParameter, out securityToken);
                return true;
            }
            catch
            {
                // if token is not valid then it throw exception
                return false;
            }
        }
    }
}