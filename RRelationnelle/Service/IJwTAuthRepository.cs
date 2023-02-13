using RessourcesRelationelles.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public interface IJwTAuthRepository
    {
        List<User> GetUsers();
    }
}
