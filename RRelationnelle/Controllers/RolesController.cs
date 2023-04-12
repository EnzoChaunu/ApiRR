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
    }
}
