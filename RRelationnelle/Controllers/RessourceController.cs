using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RessourcesRelationelles.Class;
using RRelationnelle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RessourceController : Controller
    {

        private readonly RrelationnelApiContext _context;

        public RessourceController(RrelationnelApiContext context)
        {
            _context = context;
        }

        //methode de recuperation executée de facon asynchrone
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Ressource>>> GetRessources()
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _context.Ressource.ToListAsync();
        }  
        
        
        //methode de recuperation executée de facon asynchrone
        [HttpGet("{id_ressource}")]
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
        }
    }
}
