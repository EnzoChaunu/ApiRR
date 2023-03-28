using System.Collections.Generic;
using RRelationnelle;

namespace DataAccess.Interfaces
{
    public interface IJwTAuthRepository
    {
        List<User> GetUsers();
    }
}
