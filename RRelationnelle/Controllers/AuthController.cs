﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public AuthController(IJwTAuthentificationService JwtAuthService,IConfiguration config)
        {
            this._JwtAuthService = JwtAuthService;
            this._config = config;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            var user = _JwtAuthService.Authenticate(model.Email, model.Password);
            if(user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,user.Email),

                };
                var token = _JwtAuthService.GenerateToken(_config["Jwt:Key"],claims);
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
