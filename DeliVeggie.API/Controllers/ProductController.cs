using DeliVeggie.Application.Abstracts;
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
        public IActionResult GetProductList()
        {
            var list = _productService.GetProducts();
            return Ok(list);
        }

        [HttpGet("details/{id:int}")]
        public IActionResult GetProductList(int id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }
    }
}
