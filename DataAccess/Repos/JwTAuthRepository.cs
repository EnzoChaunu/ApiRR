using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RRelationnelle
{
    public class JwTAuthRepository : IJwTAuthRepository
    {
        private readonly RrelationnelApiContext _ctx;
        public JwTAuthRepository(RrelationnelApiContext ctx)
        {
            this._ctx = ctx;
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            if (_ctx != null)
            {
                users = await _ctx.User.Include(r => r.Role).ToListAsync();
                return users;
            }
            else
            {
                return null;
            }
        }
    }
}
