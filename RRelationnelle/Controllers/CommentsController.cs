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
        private readonly CommentsService _service;

        // initialisation du service
        public CommentsController(CommentsService service)
        {
            _service = service;
        }

        [HttpGet("GetCommentsPerRessource/{idRessource}")]
        public async Task<ActionResult<CommentDto>> List(int id)
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

    }
}
