using Microsoft.AspNetCore.Mvc;
using RessourcesRelationelles.Class;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRelationnelle.Service
{
    public interface IRolesService
    {
        public Task<ActionResult<IEnumerable<Roles>>> GetAllRolesAsync();

        public Task<ActionResult<Roles>> GetRoleByUserIdAsync(int id);


    }
}
