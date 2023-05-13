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

        public async Task<Response<UserDto>> Authenticate(string email, string pswd)
        {
            List<User> userDb = new List<User>();
            userDb = await _repos.GetUsers();
            var mapper = MappingUser.UserMapperModelToDto();
            List<UserDto> UserDto = mapper.Map<List<User>, List<UserDto>>(userDb);
   
            if (UserDto != null)
            {
                try
                {

                   var user = UserDto.Where(u => u.Email.ToUpper().Equals(email.ToUpper())
                   && u.Password.Equals(pswd)).FirstOrDefault();
                    if(user != null)
                    {
                        if (user.Activation == false)
                        {
                            return new Response<UserDto>(404, user, "Votre compte a été banni");
                        }
                        else
                        {
                            return new Response<UserDto>(200, user, "Connexion réussie");
                        }
                    }
                    else
                    {
                        return new Response<UserDto>(404, null, "Votre compte n'existe pas");
                    }
                }
                catch (Exception ex)
                {
                    return new Response<UserDto>(500, null, ex.Message);
                }
            }
            else
            {
                return new Response<UserDto>(404, null, "Aucun utilisateur trouvé");
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
