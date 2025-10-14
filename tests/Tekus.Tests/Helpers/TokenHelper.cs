using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Tests.Helpers
{
    public static class TokenHelper
    {
        public static string GenerateTestJwt()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("LpFnzMKe9hBbVbLLptctcVRfZkrYXAa9"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Tekus",
                audience: "TekusUser",
                claims: new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, "testuser"),
                new Claim(ClaimTypes.Role, "Admin")
                },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
