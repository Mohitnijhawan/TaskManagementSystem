using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using TaskManagementSystem.Application.Abstraction.IJWTProvider;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.InfraStructure.JWTProvider
{
    public class JWTProvider(IConfiguration configuration) : IJWTProvider
    {
        public string GenerateAuthToken(User user)
        {
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim(UserClaims.UserId,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.UserRole.ToString()),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email,user.Email)

                }),
                Audience = configuration["JWT:Audience"],
                Issuer = configuration["JWT:Issuer"],
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (configuration["JWT:Key"]!)), SecurityAlgorithms.HmacSha384)
            };
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokendescriptor = tokenhandler.CreateToken(descriptor);
            var token = tokenhandler.WriteToken(tokendescriptor);
            return token;
        }

    }
}