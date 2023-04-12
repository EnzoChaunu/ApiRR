using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RRelationnelle.Service;
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
       
        private readonly CategoryService _service;
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

        [HttpGet("CategoryMabite")]
        public async Task<IEnumerable<CategoryDto>> List2()
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.ListCategory2();

        }


        [HttpPut("{id}")]
        public async Task<CategoryDto> Update(int id,CategoryDto categ)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var catego = await _service.Update(categ,id);
            if (categ != null)
            {
                return categ;
            }
            else
            {
                return null;
            }

        }
        
        [HttpPut("/Archive/{id}")]
        public async Task<bool> Archive(int id)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.Archive(id);
          
        }

        [HttpPost]
        //[Authorize]
        public async Task<CategoryDto> CreateCategory(CategoryDto category)
        {
            var categ = await _service.Create(category);
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
