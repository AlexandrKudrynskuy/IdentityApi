using BLL.Service;
using DLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Store_Identity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryApiController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("GetCategory")]
        public List<Category> GetBrand()
        {
            return _categoryService.GetFromCondition(x => x.Id > 0).ToList();
        }
    }
}
