using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
       
        private readonly ICategoryService _service;
        public CategoryDto categori = new CategoryDto();
       
        public CategoryController(RrelationnelApiContext context)
        {
            _service = new CategoryService(new CategoryRepository(context));
        }

        [HttpGet("CategoryAll")]
        [Authorize]
        public async Task<IEnumerable<CategoryDto>> List()
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.ListCategory2(); 
            
        }



        [HttpPost]
        public  IActionResult CreateCategory(CategoryDto category)
        {
            return Ok( _service.CreateCategory(category));
        }


    }
}
