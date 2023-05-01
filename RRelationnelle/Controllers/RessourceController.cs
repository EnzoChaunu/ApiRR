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
        
        [HttpGet("Alternances&Formations")]
        public async Task<Response<List<AlternanceDto>>> GetFormation(string romeDomain,string region)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.GetFormationForFront(romeDomain,region);
           
        }

        [HttpGet("Job")]
        public async Task<Response<List<JobDto>>> GetJob(string secteurActivite)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.GetJobForFront(secteurActivite);
        }


        [HttpPut("AddView/{id}")]
        public async Task<Response<bool>> AddViewToRessource(int id)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.AddView(id);
        }

        [HttpPost("user/{user}/ressource/{ressource}/AddToFavorites")]
        public async Task<Response<UserfavoriteRessourceDto>> AddToFavorite(int user,int ressource)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            return await _service.AddFavorite(user,ressource);
        }
    }
}
