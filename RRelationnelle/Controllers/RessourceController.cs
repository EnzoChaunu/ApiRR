using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRelationnelle.dto;
using RRelationnelle.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    [ApiController]
    [Route("api/[controller]")]
    public class RessourceController : Controller
    {

        private readonly RessourceService _service;

        public RessourceController(RessourceService service)
        {
            _service = service;
        }

       /* //methode de recuperation executée de facon asynchrone
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Ressource>>> GetRessources()
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _context.Ressource.ToListAsync();
        }  */
        
        [HttpGet("Alternances&Formations")]
        public async Task<List<AlternanceDto>> GetFormation(string rome,string romeDomain, string caller)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.GetFormation(rome,romeDomain,caller);
        }  
        
        
        //methode de recuperation executée de facon asynchrone
       /* [HttpGet("{id_ressource}")]
        public async Task<ActionResult<Ressource>> GetRessourcesById(int id_ressource)
        {
            //requete sur un id
            var ressource = await _context.Ressource.Where(c => c.ID_Ressource.Equals(id_ressource)).FirstOrDefaultAsync();
            if(ressource==null)
            {
                return NotFound();
            }
            return ressource;
        }

        [HttpPost]
        public async Task<ActionResult<Ressource>> AddRessource(Ressource ressource)
        {
             _context.Ressource.Add(ressource);
            await _context.SaveChangesAsync();
            return ressource;
        }*/
    }
}
