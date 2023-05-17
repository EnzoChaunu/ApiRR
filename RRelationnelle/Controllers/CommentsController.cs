using Commun.Responses;
using Microsoft.AspNetCore.Mvc;
using RRelationnelle;
using Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIRRelationnel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CommentsController : Controller
    {
        // declarer la variable d'acces au service
        private readonly CommentService _service;

        // initialisation du service
        public CommentsController(CommentService service)
        {
            _service = service;
        }

        [HttpGet("GetComment/{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var reponse = await _service.Get(id);
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

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentDto comment)
        {
            var reponse = await _service.Create(comment);
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

        [HttpPost]
        public async Task<IActionResult> CreateCommentWithToken(CommentDto comment, string expediteur)
        {
            var reponse = await _service.CreateWithToken(comment, expediteur);
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

        [HttpPut("ArchiveComment/{id}")]
        public async Task<IActionResult> ArchiveComment(int id)
        {
            var reponse = await _service.Archive(id);
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

        [HttpPut("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(int id, CommentDto comment)
        {
            var reponse = await _service.Update(comment, id);
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

        [HttpGet("GetCommentsPerRessource/{idRessource}")]
        public async Task<ActionResult<CommentDto>> ListPerResources(int id)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            Response<List<CommentDto>> reponse = await _service.GetCommentsPerRessource(id);

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

        [HttpGet("GetCommentsPerRessource/{idUser}")]
        public async Task<ActionResult<CommentDto>> ListPerUser(int id)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            Response<List<CommentDto>> reponse = await _service.GetCommentsPerUser(id);

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

    }
}
