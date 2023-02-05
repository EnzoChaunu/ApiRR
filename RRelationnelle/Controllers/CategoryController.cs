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
       
        private readonly ICategoryService _service;
        public Category categori = new Category();
       
        public CategoryController(RrelationnelApiContext context)
        {
            _service = new CategoryService(new CategoryRepository(context));
        }

        [HttpGet("CategoryAll")]
        public async Task<IEnumerable<Category>> List()
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.ListCategory2(); 
            
        }



        [HttpPost]
        public  IActionResult CreateCategory(Category category)
        {
            return Ok( _service.CreateCategory(category));
        }


    }
}
