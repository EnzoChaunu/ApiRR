using Commun.dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RRelationnelle
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly RolesService _service;

        public RolesController(RrelationnelApiContext context)
        {
            _service = new RolesService(new RolesRepository(context));
        }

        [HttpPost]
        //[Authorize]
        public async Task<RolesDto> CreateRole(RolesDto role)
        {
            var roleObject = await _service.Create(role);
            if (roleObject != null)
            {
                return roleObject;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("GetUserRole/{id}")]
        public async Task<ActionResult<RolesDto>> GetUserRole(int idUser)
        {
            return await _service.GetRoleByUserIdAsync(idUser);
        }

        [HttpPut("ArchiveRole/")]
        public async Task<bool> ArchiveRole(int id)
        {
            return await _service.Archive(id);
        }

        [HttpPut("UpdateRole/{id}")]
        public async Task<RolesDto> UpdateRole(RolesDto role, int id)
        {
            return await _service.Update(role, id);
        }
    }
}
