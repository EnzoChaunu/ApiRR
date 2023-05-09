using Commun.Responses;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public interface IJwTAuthentificationService
    {
        Task<Response<UserDto>> Authenticate(string email, string pswd);
        Task<Response<string>> GenerateToken(string secretKey, List<Claim> claim);

    }
}
