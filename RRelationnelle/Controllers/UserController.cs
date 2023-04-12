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
       

        //[HttpPost]
        ////[Authorize]
        //public async Task<UserDto> CreateCategory(CategoryDto category)
        //{
        //    return await _service.Create(category);
          
        //}
    }
}
