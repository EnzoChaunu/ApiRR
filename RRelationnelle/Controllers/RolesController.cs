using Microsoft.AspNetCore.Mvc;
using RRelationnelle.Models;
using RRelationnelle.Service;

namespace RRelationnelle.Controllers
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


        public IActionResult Index()
        {
            return View();
        }
    }
}
