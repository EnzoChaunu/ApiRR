using Commun.Responses;
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
       
        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet("CategoryAll")]
        public async Task<ActionResult<CategoryDto>> List()
        {
            //await = attendre de facon asynchrone la fin d'une tache
            Response<List<CategoryDto>> reponse =  await _service.ListCategory2(); 

            if (reponse.ResponseCode == 200)
            {
                return Ok(reponse);
            }
            else if (reponse.ResponseCode == 404)
            {
                return NotFound(reponse);
            }
            else
            {
                return StatusCode(500, reponse);
            }
            
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
