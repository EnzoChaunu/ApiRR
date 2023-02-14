using Microsoft.IdentityModel.Tokens;
using RessourcesRelationelles.Class;
using RRelationnelle.Auth;
using RRelationnelle.Mapping;
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
        private List<UserDto> users;
        private readonly IJwTAuthRepository _repos;
        public JwtAuthentificationServices(IJwTAuthRepository repos)
        {
            _repos = repos;
        }

        public UserDto Authenticate(string email, string pswd)
        {
            List<User> userDb = new List<User>();
            userDb = _repos.GetUsers();
            var mapper = MappinLog.MappingUser();
            List<UserDto> UserDto = mapper.Map<List<User>, List<UserDto>>(userDb);
   
            if (UserDto != null)
            {
                try
                {

                    return UserDto.Where(u => u.Email.ToUpper().Equals(email.ToUpper())
                   && u.Password.Equals(pswd)).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
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
