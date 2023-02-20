using Microsoft.AspNetCore.Mvc;

namespace RRelationnelle
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly IRolesService _service;

        public RolesController(RrelationnelApiContext context)
        {
            _service = new RolesService(new RolesRepository(context));
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
