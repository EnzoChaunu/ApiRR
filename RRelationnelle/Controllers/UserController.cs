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
        public async Task<UserDto> GetUser(int id)
        {
            return await _service.Get(id);
        }

        [HttpPut("ArchiveUser/{id}")]
        public async Task<bool> ArchiveUser(int id)
        {
            return await _service.Archive(id);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<UserDto> UpdateUser(UserDto user, int id)
        {
            if (user != null) 
                return await _service.Update(user, id);
            else return null;
        }

        [HttpPost]
        //[Authorize]
        public async Task<UserDto> CreateUser(UserDto user)
        {
            var userObject = await _service.Create(user);
            if (userObject != null)
            {
                return userObject;
            }
            else
            {
                return null;
            }
        }

        //[HttpPost]
        ////[Authorize]
        //public async Task<UserDto> CreateCategory(CategoryDto category)
        //{
        //    return await _service.Create(category);

        //}
    }
}
