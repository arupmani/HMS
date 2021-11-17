using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using HMSWeb.Utilities;
using Microsoft.AspNetCore.Authorization;
using HMSWeb.DomainViewModel;
using HMSDAL.Repository;

namespace HMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        IUserRepository userRepository;
        private IConfiguration config;
        private readonly IJwtAuth jwtAuth;
        public TokenController(IConfiguration configuration, IJwtAuth jwtAuth, IUserRepository _userRepository)
        {
            config = configuration;
            this.jwtAuth = jwtAuth;
            userRepository = _userRepository;
        }

        [AllowAnonymous]
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserModel userCredential)
        {
            var token = jwtAuth.Authentication(userCredential.UserName, userCredential.Password, userRepository);
            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" }); 

            userCredential.Password = string.Empty;
            userCredential.Token = token;
            return Ok(userCredential);
        }

    }
}
