using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public interface IJwTAuthRepository
    {
        List<User> GetUsers();
    }
}
