using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly RrelationnelApiContext _Dbcontext;

        public UserRepo(RrelationnelApiContext context)
        {
            _Dbcontext = context;

        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _Dbcontext.User.FindAsync(id);
            return user;
        }
    }
}
