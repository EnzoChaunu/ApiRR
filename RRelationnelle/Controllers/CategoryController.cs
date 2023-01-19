using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourcesRelationelles.Class;
using RRelationnelle.Modèles;
using RRelationnelle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
       private ICategoryService _service;
       private readonly RrelationnelApiContext _cxt;

        public CategoryController(ICategoryService service, RrelationnelApiContext ctx)
        {
            _service = service;
            _cxt = ctx;
        }

       

        [HttpPost]
        public IActionResult CreateCategory (Categorie category)
        {
            if (_service.CreateCategory(category))
            {
                return View();
            }else
            {
                return RedirectToAction("Index");
            }
        }


    }
}
