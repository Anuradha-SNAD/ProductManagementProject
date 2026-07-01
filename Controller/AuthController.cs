using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Service;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductManagement.Controllers.V3
{
    [ApiController]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [SwaggerTag("Authentication Operations")]
    public class AuthController : ControllerBase
    {
        private readonly IProductService service;

        public AuthController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get All", Description = "Get All Product Details")]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

    }
}