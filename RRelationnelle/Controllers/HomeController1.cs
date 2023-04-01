using Microsoft.AspNetCore.Mvc;

namespace APIRRelationnel.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
