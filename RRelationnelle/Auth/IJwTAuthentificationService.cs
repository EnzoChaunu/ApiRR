using RessourcesRelationelles.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RRelationnelle.Auth
{
    public interface IJwTAuthentificationService
    {
        User Authenticate(string email, string pswd);
        string GenerateToken(string secretKey, List<Claim> claim);
    }
}
