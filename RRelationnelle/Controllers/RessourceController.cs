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
        public async Task<IActionResult> GetFormation(string romeDomain,string region)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var reponse = await _service.GetFormationForFront(romeDomain,region);
            if (reponse.ResponseCode==200)
            {
                return Ok(reponse);
            }
            else if (reponse.ResponseCode==500)
            {
                return BadRequest(reponse);
            }else
            {
                return NotFound(reponse);
            }
           
        }

        [HttpGet("Job")]
        public async Task<IActionResult> GetJob(string secteurActivite)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var reponse = await _service.GetJobForFront(secteurActivite);
            if (reponse.ResponseCode == 200)
            {
                return Ok(reponse);
            }
            else if (reponse.ResponseCode == 500)
            {
                return BadRequest(reponse);
            }
            else
            {
                return NotFound(reponse);
            }
        }


        [HttpPut("AddView/{id}")]
        public async Task<IActionResult> AddViewToRessource(int id)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var reponse = await _service.AddView(id);
            if (reponse.ResponseCode == 200)
            {
                return Ok(reponse);
            }
            else if (reponse.ResponseCode == 500)
            {
                return BadRequest(reponse);
            }
            else
            {
                return NotFound(reponse);
            }
        }

        [HttpPost("user/{user}/ressource/{ressource}/AddToFavorites")]
        public async Task<IActionResult> AddToFavorite(int user,int ressource)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var reponse = await _service.AddFavorite(user,  ressource);
            if (reponse.ResponseCode == 200)
            {
                return Ok(reponse);
            }
            else if (reponse.ResponseCode == 500)
            {
                return BadRequest(reponse);
            }
            else
            {
                return NotFound(reponse);
            }
        }

        [HttpPost("user/{expediteur}/ressource/{ress}/destinataire/{destinataireEmail}/ShareRessource")]
        public async Task<IActionResult> ShareRessource(int ress, int expediteur, string destinataireEmail)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var reponse = await _service.ShareRessource(ress, expediteur,destinataireEmail);
            if (reponse.ResponseCode == 200)
            {
                return Ok(reponse);
            }
            else if (reponse.ResponseCode == 500)
            {
                return BadRequest(reponse);
            }
            else
            {
                return NotFound(reponse);
            }
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetRessourceByUser(int idUser)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var reponse = await _service.GetListRessourceByUser(idUser);
            if (reponse.ResponseCode == 200)
            {
                return Ok(reponse);
            }
            else if (reponse.ResponseCode == 500)
            {
                return BadRequest(reponse);
            }
            else
            {
                return NotFound(reponse);
            }
        }
    }
}
