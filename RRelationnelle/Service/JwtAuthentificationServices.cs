using Microsoft.IdentityModel.Tokens;
using RessourcesRelationelles.Class;
using RRelationnelle.Auth;
using RRelationnelle.Modèles;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public class JwtAuthentificationServices : IJwTAuthentificationService
    {
        private readonly List<UserDto> users;

        public UserDto Authenticate(string email, string pswd)
        {
            return users.Where(u => u.Email.ToUpper().Equals(email.ToUpper())
                && u.Password.Equals(pswd)).FirstOrDefault();
        }

        public string GenerateToken(string secretKey, List<Claim> claim)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
