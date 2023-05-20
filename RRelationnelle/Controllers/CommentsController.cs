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

        [HttpPost("PostCommentWithToken")]
        public async Task<IActionResult> CreateCommentWithToken(CommentDto comment)
        {
            if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var token = authHeader.ToString().Replace("Bearer ", "");
                var reponse = await _service.CreateWithToken(comment, token);
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
            else
            {
                return Unauthorized();
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
        public async Task<ActionResult<CommentDto>> ListPerResources(int idRessource)
        {
            //await = attendre de facon asynchrone la fin d'une tache
            Response<List<CommentDto>> reponse = await _service.GetCommentsPerRessource(idRessource);

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

        [HttpGet("GetCommentsPerUser/{idUser}")]
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
