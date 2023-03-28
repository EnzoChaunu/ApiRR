using System.Collections.Generic;
using System.Security.Claims;

namespace RRelationnelle
{
    public interface IJwTAuthentificationService
    {
        UserDto Authenticate(string email, string pswd);
        string GenerateToken(string secretKey, List<Claim> claim);

    }
}
