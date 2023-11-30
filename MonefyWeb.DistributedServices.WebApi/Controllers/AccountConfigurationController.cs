using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Account_Configuration;
using MonefyWeb.DistributedServices.WebApi.Contracts;
using MonefyWeb.DistributedServices.WebApi.Validations;
using MonefyWeb.Transversal.Aspects;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace MonefyWeb.DistributedServices.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class AccountConfigurationController : ControllerBase, IAccountConfigurationController
    {
        private readonly IAccountConfigurationService _application;
        private readonly Transversal.Utils.ILogger _log;
        private readonly IMapper _mapper;

        public AccountConfigurationController(
            IAccountConfigurationService _application,
            Transversal.Utils.ILogger _log,
            IMapper _mapper
        )
        {
            this._application = _application;
            this._log = _log;
            this._mapper = _mapper;
        }

        [Log]
        [Timer]
        //[Authorize]
        [HttpGet("GetAccountConfiguration")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success")]
        [SwaggerOperation("GetAccountConfiguration")]
        public IActionResult GetAccountConfiguration(
            [SwaggerRequestBody(Required = true)][FromQuery] long AccountId,
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version
        )
        {
            var result = _application.GetAccountConfiguration(AccountId);
            var validator = new AccountConfigurationValidator();
            var results = validator.Validate(result);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            return Ok(result);
        }

        [Log]
        [Timer]
        //[Authorize]
        [HttpPost("SetAccountConfiguration")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success")]
        [SwaggerOperation("SetAccountConfiguration")]
        public IActionResult SetAccountConfiguration(
            [SwaggerRequestBody(Required = true)][FromBody] AccountConfigurationDto config,
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version
        )
        {
            return Ok(_application.SetAccountConfiguration(config));
        }
    }
}
