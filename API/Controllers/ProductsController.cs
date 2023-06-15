using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loosely coupled
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetProducts() 
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product) 
        { 
            var result= _productService.Add(product);
            if (result.Success) 
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int productId)
        {
            var result= _productService.GetProduct(productId);
            if (result.Success)
            { 
                return Ok(result); 
            }
            return BadRequest(result);
        }
    }
}
