using Microsoft.AspNetCore.Mvc;
using RRelationnelle;
using RRelationnelle.Repos;
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
