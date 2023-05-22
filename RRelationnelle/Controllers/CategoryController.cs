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
        public async Task<Response<List<CategoryDto>>> List()
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var reponse =  await _service.ListCategory2();
            return reponse;
            
        }

        [HttpPut("{id}")]
        public async Task<Response<CategoryDto>> Update(int id,CategoryDto categ)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var catego = await _service.Update(categ,id);
            return catego;

        }
        
        [HttpPut("/Archive/{id}")]
        public async Task<Response<bool>>Archive(int id)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var reponse =  await _service.Archive(id);
            return reponse;

        }

        [HttpPost]
        //[Authorize]
        public async Task<Response<CategoryDto>> CreateCategory(CategoryDto category)
        {
            var reponse = await _service.Create(category);
            return reponse;

        }


    }
}
