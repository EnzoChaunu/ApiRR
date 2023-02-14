using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RRelationnelle
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string> { "toto", "bilou" };
        }
    }
}
