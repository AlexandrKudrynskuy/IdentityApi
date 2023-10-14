using BLL.Service;
using DLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Store_Identity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminCategoryApiController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public AdminCategoryApiController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult AddBrand([FromBody] Category categorey)
        {
            try
            {
                _categoryService.Create(categorey);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetCategory")]
        public List<Category> GetBrands()
        {
            return _categoryService.GetFromCondition(x => x.Id > 0).ToList();
        }

        [HttpPost]
        [Route("GetPhoto")]
        public string GetPhoto([FromBody] int id)
        {
            return _categoryService.GetFromCondition(x => x.Id == id).ToList().First().Photo;
        }




        [HttpPost]
        [Route("UpdateCategory")]
        public IActionResult UpdateBrand([FromBody] Category category)
        {
            try
            {
                _categoryService.Update(category.Id, category);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

    }
}
