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
        public async Task<Response<UserDto>> GetUser(int id)
        {
            return await _service.Get(id);
        }

        [HttpPut("ArchiveUser/{id}")]
        public async Task<Response<bool>> ArchiveUser(int id)
        {
            return await _service.Archive(id);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<Response<UserDto>> UpdateUser(UserDto user, int id)
        {
            return await _service.Update(user, id); 
        }

        [HttpPost]
        public async Task<Response<UserDto>> CreateUser(UserDto user)
        {
            return await _service.Create(user);
           
        }
    }
}
