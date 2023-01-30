using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RessourcesRelationelles.Class;
using RRelationnelle.Modèles;
using RRelationnelle.Models;
using RRelationnelle.Service;
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
        private readonly RrelationnelApiContext ctx;
        private readonly ICategoryService _service;
        public Category categori = new Category();
       /* public CategoryController(ICategoryService service)
        {
            _service = service;
            
        }*/

        public CategoryController(RrelationnelApiContext _ctx)
        {
            ctx = _ctx;
            _service = new CategoryService(new CategoryRepository(ctx));

        }

        [HttpGet("CategoryAll")]
        public async Task<ActionResult<IEnumerable<Categorie>>> List()
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var p = await _service.ListCategory(); ;
            return p;
        }



        [HttpPost]
        public async Task<ActionResult> CreateCategory (Categorie category)
        {
            /* if (_service.CreateCategory(category))
             {
                 return View();
             }else
             {
                 return RedirectToAction("Index");
             }*/
            return  View();
        }


    }
}
