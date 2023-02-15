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
        public async Task<IEnumerable<CategoryDto>> List()
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.ListCategory2(); 
            
        }
        
        
        [HttpPut("{id}")]
        public async Task<CategoryDto> Update(int id,CategoryDto categ)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var catego = await _service.UpdateCategory(categ,id);
            if (categ != null)
            {
                return categ;
            }
            else
            {
                return null;
            }

        }



        [HttpPost]
        [Authorize]
        public async Task<CategoryDto> CreateCategory(CategoryDto category)
        {
            var categ = await _service.CreateCategory(category);
            if (categ!= null)
            {
                return categ;
            }
            else
            {
                return null;
            }
        }


    }
}
