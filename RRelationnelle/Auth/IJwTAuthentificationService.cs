using RessourcesRelationelles.Class;
using RRelationnelle.Modèles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RRelationnelle.Auth
{
    public interface IJwTAuthentificationService
    {
        UserDto Authenticate(string email, string pswd);
        string GenerateToken(string secretKey, List<Claim> claim);

    }
}
