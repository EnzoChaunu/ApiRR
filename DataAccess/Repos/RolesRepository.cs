using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RRelationnelle
{
    public class RolesRepository : IRepository<Roles>
    {
        private readonly RrelationnelApiContext _ctx;

        public RolesRepository(RrelationnelApiContext ctx)
        {
            _ctx = ctx;
        }

        public Task<bool> Archive(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Roles> Create(Roles obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Roles> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<Roles>>> GetAllRolesAsync()
        {
            List<Roles> roles = new List<Roles>();
            roles = await _ctx.Role.ToListAsync();
            return roles;
        }

        public async Task<ActionResult<Roles>> GetRoleByUserIdAsync(int id)
        {
            Roles UserRole = new Roles();
            UserRole = await _ctx.Role.FindAsync(id);
            return UserRole;
        }

        public Task<Roles> Update(Roles obj, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
