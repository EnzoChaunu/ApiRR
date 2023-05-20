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
            var user =  await _JwtAuthService.Authenticate(model.Email, model.Password);
            if(user.ResponseCode != 404 || user.ResponseCode != 500)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,user.Data.Email),
                    new Claim(ClaimTypes.Name,user.Data.FName),
                    new Claim(ClaimTypes.Surname,user.Data.LName),
                    new Claim("Idrole",user.Data.IdRole.ToString())

                };
                var token = await _JwtAuthService.GenerateToken(_config["Jwt:Key"],claims);
                var reponse  = await _user.UpdateUserToken(user.Data.Id,token);
                return Ok(token);
            }
            else
            {
                return Unauthorized(user);

            }
        }
    }
}
