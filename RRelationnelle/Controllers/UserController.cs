using Commun.Responses;
using Microsoft.AspNetCore.Mvc;
using RRelationnelle;
using RRelationnelle.Services;
using System.Threading.Tasks;

namespace APIRRelationnel
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }



        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var reponse = await _service.Get(id);
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
        
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var reponse = await _service.GetAll();
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


        [HttpPut("ArchiveUser/{id}")]
        public async Task<IActionResult> ArchiveUser(int id)
        {
            var reponse = await _service.Archive(id);
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

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(UserDto user, int id)
        {
            var reponse = await _service.Update(user, id);
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

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            var reponse = await _service.Create(user);
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

        [HttpGet("GetUserListByRole/{role}")]
        public async Task<IActionResult> GetUserListByRole(string role)
        {
            var response = await _service.GetUserListByRole(role);
            if (response.ResponseCode == 200)
            {
                return Ok(response);
            }
            else if (response.ResponseCode == 500)
            {
                return BadRequest(response);
            }
            else
            {
                return NotFound(response);
            }

        }
    }
}
