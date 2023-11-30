using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Categories;
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
    public class CategoryController : ControllerBase, ICategoryController
    {
        private readonly ICategoryService _application;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;


        public CategoryController(ICategoryService _application, Transversal.Utils.ILogger _log, IMapper mapper)
        {
            this._application = _application;
            this._log = _log;
            _mapper = mapper;
        }

        [Log]
        [Timer]
        //[Authorize]
        [HttpGet("GetCategories")]
        public IActionResult GetCategories(
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version
        )
        {
            var result = _mapper.Map<List<CategoryDto>>(_application.GetCategories());
            var validator = new CategoriesListValidator();
            var results = validator.Validate(result);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    return BadRequest(failure);
                }
            }

            return Ok(result);
        }

        [Log]
        [Timer]
        //[Authorize]
        [HttpGet("GetCategoriesByUserId")]
        public IActionResult GetCategoriesByUserId(
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version,
            [SwaggerParameter("1")][DefaultValue(1)][FromQuery] long UserId
        )
        {
            var result = _mapper.Map<List<CategoryDto>>(_application.GetCategoriesByUserId(UserId));
            var validator = new CategoriesListValidator();
            var results = validator.Validate(result);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    return BadRequest(failure);
                }
            }

            return Ok(result);
        }
    }
}
