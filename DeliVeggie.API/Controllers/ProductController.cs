using DeliVeggie.Application.Abstracts;
using DeliVeggie.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliVeggie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("list")]
        public IActionResult GetProductList(int offset, int limit)
        {
            var list = _productService.GetProducts(offset, limit);
            return Ok(list);
        }

        [HttpGet("details/{id}")]
        public IActionResult GetProductList(string id)
        {
            var product = _productService.GetProductById(id);
            
            return Ok(product);
        }
    }
}
