using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Users;
using MonefyWeb.DistributedServices.WebApi.Contracts;
using MonefyWeb.Transversal.Aspects;
using MonefyWeb.Transversal.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace MonefyWeb.DistributedServices.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserService _application;
        private readonly IAuthenticationService _authentication;
        private readonly Transversal.Utils.ILogger _log;


        public UserController(IUserService _application, Transversal.Utils.ILogger _log, IAuthenticationService authentication)
        {
            this._application = _application;
            this._log = _log;
            _authentication = authentication;
        }

        [Log]
        [Timer]
        [Authorize]
        [HttpGet("GetUserData")]
        public IActionResult GetUserData(
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version,
            [SwaggerParameter("1")][DefaultValue(1)][FromQuery] long UserId
        )
        {
            var result = _application.GetUserData(UserId);
            if (result != new UserDataResponseDto()) { return Ok(result); }
            return BadRequest(result);
        }

        [Log]
        [Timer]
        [HttpPost("Login")]
        public IActionResult Login(
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version,
            LoginRequestDto request
        )
        {
            var result = _application.LoginUser(request);
            if (result.Status == true) 
            {
                var generatedToken = _authentication.GenerateToken(result.UserId);
                return Ok(new { token = generatedToken });
            }
            return BadRequest("");
        }

        [Log]
        [Timer]
        [HttpPost("Register")]
        public IActionResult Register(
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version,
            RegisterRequestDto request)
        {
            var result = _application.RegisterUser(request);
            if (result.Status == true) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
