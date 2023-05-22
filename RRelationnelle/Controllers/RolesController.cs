using Commun.dto;
using Commun.Responses;
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
        public async Task<Response<RolesDto>> CreateRole(RolesDto role)
        {
            return await _service.Create(role);
            
        }

        [HttpGet("GetUserRole/{id}")]
        public async Task<Response<RolesDto>> GetUserRole(int idUser)
        {
            return await _service.GetRoleByUserIdAsync(idUser);
        }

        [HttpPut("ArchiveRole/{name}")]
        public async Task<Response<bool>> ArchiveRole(string name)
        {
            return await _service.ArchiveByName(name);
        }

        [HttpPut("UpdateRole/{id}")]
        public async Task<Response<RolesDto>> UpdateRole(RolesDto role, int id)
        {
            return await _service.Update(role, id);
        }
    }
}
