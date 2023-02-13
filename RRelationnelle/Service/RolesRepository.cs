using Microsoft.AspNetCore.Mvc;
using RRelationnelle.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RessourcesRelationelles.Class;
using Microsoft.EntityFrameworkCore;

namespace RRelationnelle.Service
{
    public class RolesRepository : IRolesRepository
    {
        private readonly RrelationnelApiContext _ctx;

        public RolesRepository(RrelationnelApiContext ctx)
        {
            _ctx = ctx;
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

    }
}
