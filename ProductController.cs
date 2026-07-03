using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.DTOs;
using ProductManagement.Repository;
using ProductManagement.Service;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductManagement.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [SwaggerTag("Product Management CRUD API's")]
    [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Add Product",Description = "Add Product Details")]
        public IActionResult Add(ProductRequestDTO dto)
        {
            service.Add(dto);
            return Ok("Product Added Successfully");
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get All", Description = "Get All Product Details")]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get BY Id", Description = "Get Product Details By Product Id")]
        public IActionResult GetById(int id)
        {
            return Ok(service.GetById(id));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update Product", Description = "Update Product Details By Id")]
        public IActionResult Update(int id,ProductRequestDTO dto)
        {
            service.Update(id, dto);
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete Product", Description = "Delete Product Details By Id")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok("Product Deleted Successfully ");
        }

    }
}
