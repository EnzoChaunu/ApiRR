using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public interface IRolesService
    {
        public Task<ActionResult<IEnumerable<Roles>>> GetAllRolesAsync();

        public Task<ActionResult<Roles>> GetRoleByUserIdAsync(int id);


    }
}
