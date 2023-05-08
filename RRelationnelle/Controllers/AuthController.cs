using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RRelationnelle.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RRelationnelle
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IJwTAuthentificationService _JwtAuthService;
        private readonly IConfiguration _config;
        private readonly UserService _user;
        public AuthController(IJwTAuthentificationService JwtAuthService,IConfiguration config,UserService usServ)
        {
            this._JwtAuthService = JwtAuthService;
            this._config = config;
            _user = usServ;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = _JwtAuthService.Authenticate(model.Email, model.Password);
            if(user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Name,user.FName),
                    new Claim("Idrole",user.IdRole.ToString())

                };
                var token = await _JwtAuthService.GenerateToken(_config["Jwt:Key"],claims);
                var reponse  = await  _user.UpdateUserToken(user.Id,token);
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
