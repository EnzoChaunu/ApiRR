using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Repos
{
    public interface IUserRepo
    {
        public Task<User> GetUserById(int id);
    }
}
