using Commun.dto;
using Commun.Responses;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetFormation(string romeDomain, string region)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var reponse = await _service.GetFormationForFront(romeDomain, region);
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
          [HttpGet("GetRessource/{reference}")]
        public async Task<IActionResult> GetRessource(string reference)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            var reponse = await _service.GetRessource(reference);
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

        [HttpPost("ressource/{ressource}/AddToFavorites")]
        public async Task<IActionResult> AddToFavorite(int ressource)
        {
            if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var token = authHeader.ToString().Replace("Bearer ", "");

                //await = attendre de facon asynchrone la fin d'une tache
                var reponse = await _service.AddFavorite(token, ressource);
                if (reponse.ResponseCode == 200)
                {
                    return Ok(reponse);
                }
                else if (reponse.ResponseCode == 500)
                {
                    return BadRequest(reponse);
                }
                else if (reponse.ResponseCode == 401)
                {
                    return Unauthorized();
                }
                else
                {
                    return NotFound(reponse);
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("ressource/{ress}/destinataire/{destinataireEmail}/ShareRessource")]
        [Authorize]
        public async Task<IActionResult> ShareRessource(int ress, string destinataireEmail)
        {

            if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var token = authHeader.ToString().Replace("Bearer ", "");
                var reponse = await _service.ShareRessource(ress, token, destinataireEmail);
                if (reponse.ResponseCode == 200)
                {
                    return Ok(reponse);
                }
                else if (reponse.ResponseCode == 500)
                {
                    return BadRequest(reponse);
                }
                else if (reponse.ResponseCode == 401)
                {
                    return Unauthorized();
                }
                else
                {
                    return NotFound(reponse);
                }
            }
            else
            {
                return Unauthorized();
            }
            //await = attendre de facon asynchrone la fin d'une tache
        }

        [HttpGet("RessourceByUser")]
        [Authorize]
        public async Task<IActionResult> GetRessourceByUser()
        {
            if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var token = authHeader.ToString().Replace("Bearer ", "");

                //await = attendre de facon asynchrone la fin d'une tache
                var reponse = await _service.GetListRessourceByUser(token);
                if (reponse.ResponseCode == 200)
                {
                    return Ok(reponse);
                }
                else if (reponse.ResponseCode == 500)
                {
                    return BadRequest(reponse);
                }
                else if (reponse.ResponseCode == 401)
                {
                    return Unauthorized();
                }
                else
                {
                    return NotFound(reponse);
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
