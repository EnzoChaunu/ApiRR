using Commun.dto;
using Commun.Responses;
using Microsoft.AspNetCore.Mvc;
using RRelationnelle.dto;
using RRelationnelle.Service;
using System.Collections.Generic;
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
        public async Task<Response<List<AlternanceDto>>> GetFormation(string rome,string romeDomain, string caller,string region)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.GetFormation(rome,romeDomain,caller,region);
        }

        [HttpGet("Job")]
        public async Task<Response<List<JobDto>>> GetJob(string secteurActivite, string departement)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.GetJob(secteurActivite,departement);
        }


        [HttpPut("AddView/{id}")]
        public async Task<bool> AddViewToRessource(int id)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.AddView(id);
        }

        /*  [HttpGet("Alternances&Formations/")]
          public async Task<List<AlternanceDto>> GetFormationByCity(string rome, string romeDomain, string caller)
          {
              //await = attendre de facon asynchrone la fin d'une tache
              return await _service.GetFormation(rome, romeDomain, caller);
          }*/

        /*  [HttpGet("Alternances&Formations/")]
          public async Task<List<AlternanceDto>> GetFormationByRomeDomain(string romeDomain)
          {
              //await = attendre de facon asynchrone la fin d'une tache
              return await _service.GetFormation(romeDomain);
          }*/


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
