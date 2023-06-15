using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        
        [HttpGet]
        public string Get()
        {
            /* return new List<Product>
             {
                 new Product {ProductId=1, CategoryId = 1,ProductName="ff",UnitPrice=5,UnitsInStock=10},
                 new Product {ProductId=1, CategoryId = 1,ProductName="ff",UnitPrice=5,UnitsInStock=10 } 
             };*/
            return "hello";
        }


    }
}
