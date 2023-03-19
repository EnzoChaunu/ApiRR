using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;

namespace RRelationnelle
{
    public class JwTAuthRepository : IJwTAuthRepository
    {
        private readonly RrelationnelApiContext _ctx;
        public JwTAuthRepository(RrelationnelApiContext ctx)
        {
            this._ctx = ctx;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            if (_ctx != null)
            {
                users = _ctx.User.ToList();
                return users;
            }
            else
            {
                return null;
            }
        }
    }
}
