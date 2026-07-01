using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Service;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductManagement.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [SwaggerTag("Product Search,Sort,Pagination Operations")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }
        [HttpGet]
        [SwaggerOperation(Summary = "Get All", Description = "Get All Product Details")]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }


        [HttpGet("search/name")]
        [SwaggerOperation(Summary = "Search Product By Name",Description = "Search products by name.")]
        public IActionResult SearchByName(string name)
        {
            return Ok(service.SearchByName(name));
        }

        [HttpGet("search/brand")]
        [SwaggerOperation( Summary = "Search Product By Brand", Description = "Search products by brand.")]
        public IActionResult SearchByBrand(string brand)
        {
            return Ok(service.SearchByBrand(brand));
        }

        [HttpGet("search/price")]
        [SwaggerOperation( Summary = "Search Product By Price", Description = "Search products between minimum and maximum price.")]
        public IActionResult SearchByPrice(decimal minPrice, decimal maxPrice)
        {
            return Ok(service.SearchByPrice(minPrice, maxPrice));
        }

        [HttpGet("sort/price")]
        [SwaggerOperation( Summary = "Sort Products By Price",Description = "Sort products by price from low to high.")]
        public IActionResult SortByPrice()
        {
            return Ok(service.SortByPrice());
        }

        [HttpGet("sort/name")]
        [SwaggerOperation(Summary = "Sort Products By Name", Description = "Sort all products alphabetically.")]
        public IActionResult SortByName()
        {
            return Ok(service.SortByName());
        }

        [HttpGet("pagination")]
        [SwaggerOperation( Summary = "Pagination", Description = "Retrieve products page by page.")]
        public IActionResult Pagination(int pageNumber = 1, int pageSize = 5)
        {
            return Ok(service.Pagination(pageNumber, pageSize));
        }
    }
}
