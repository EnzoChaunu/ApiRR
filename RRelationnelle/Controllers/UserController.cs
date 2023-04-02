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

        public UserController()
        {
            _service = new UserService();
        }
       

        //[HttpPost]
        ////[Authorize]
        //public async Task<UserDto> CreateCategory(CategoryDto category)
        //{
        //    return await _service.Create(category);
          
        //}
    }
}
