using Commun.Responses;
using DataAccess.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public class JwtAuthentificationServices : IJwTAuthentificationService
    {
        private List<UserDto> users;
        private readonly IJwTAuthRepository _repos;
        public JwtAuthentificationServices(IJwTAuthRepository repos)
        {
            _repos = repos;
        }

        public async Task<UserDto> Authenticate(string email, string pswd)
        {
            List<User> userDb = new List<User>();
            userDb = await _repos.GetUsers();
            var mapper = MappingUser.UserMapperModelToDto();
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

        public async Task<Response<string>> GenerateToken(string secretKey, List<Claim> claim)
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
            return await Task.FromResult(new Response<string>(200, tokenHandler.WriteToken(token), "new token"));
            
        }
    }
}
