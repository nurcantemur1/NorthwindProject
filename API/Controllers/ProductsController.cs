using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Product> GetProducts() 
        {
            return new List<Product>() {
            new Product { ProductId=1,CategoryId=2,ProductName="g",UnitPrice=8,UnitsInStock=9},
            new Product {ProductId=1,CategoryId=2,ProductName="f",UnitPrice=8,UnitsInStock=9 }
            };
        }
    }
}
