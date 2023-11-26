using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Accounts;
using MonefyWeb.DistributedServices.Models.Models.Movements;
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
    public class AccountController : ControllerBase, IAccountController
    {
        private readonly IAccountService _application;
        private readonly Transversal.Utils.ILogger _log;
        private readonly IMapper _mapper;

        public AccountController(IAccountService _application, Transversal.Utils.ILogger _log, IMapper _mapper)
        {
            this._application = _application;
            this._log = _log;
            this._mapper = _mapper;
        }

        [Log]
        [Timer]
        [HttpPost("AddMovementToAccount")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success")]
        [SwaggerOperation("AddMovementToAccount")]
        public IActionResult AddMovementToAccount(
            [SwaggerRequestBody(Required = true)][FromBody] MovementRequestDto movement,
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version
        )
        {
            var validator = new MovementRequestValidator();
            var validationResult = validator.Validate(movement);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(_application.AddMovementToAccount(movement));
        }

        [Log]
        [Timer]
        [HttpPost("GetAccountDataById")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success")]
        [SwaggerOperation("GetAccountDataById")]
        public IActionResult GetAccountDataById(
            [SwaggerParameter("1")][DefaultValue(1)][FromQuery] long UserId,
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version
        )
        {
            var validator = new AccountDataRequestValidator();
            var validationResult = validator.Validate(UserId);

            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errores);
            }
            return Ok(_application.GetAccountByUserId(UserId));
        }

        [Log]
        [Timer]
        [HttpPost("GetMovementsByAccountId")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success")]
        [SwaggerOperation("GetMovementsByAccountId")]
        public IActionResult GetMovementsByAccountId(
            [SwaggerParameter("1")][DefaultValue(1)][FromQuery] long AccountId,
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version
        )
        {
            var validator = new AccountDataRequestValidator();
            var validationResult = validator.Validate(AccountId);

            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errores);
            }
            var result = _mapper.Map<List<AccountMovementDto>>(_application.GetMovementsByAccountId(AccountId));
            return Ok(result);
        }

    }
}
