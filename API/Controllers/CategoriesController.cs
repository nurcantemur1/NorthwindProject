using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_categoryService.GetAllCategories();
            if (result.Success)
            {
                return Ok(result);
            } 
            return BadRequest(result.Message);
        }
        [HttpGet("get/id")]
        public IActionResult Get(int id) 
        {
            var result=_categoryService.GetCategoryById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetCategoryByName/name")]
        public IActionResult GetCategoryByName(string name)
        {
            var result = _categoryService.GetCategoryByName(name);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Add")]
        public IActionResult Add(Category category)
        {
            _categoryService.Add(category);
            return Ok("eklendim ben");
        }
    }
}
