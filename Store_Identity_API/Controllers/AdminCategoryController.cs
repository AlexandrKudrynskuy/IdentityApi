using Microsoft.AspNetCore.Mvc;

namespace Store_Identity_API.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult AddCategory()
        {
            return View();
        }

        public IActionResult UpdateCategory()
        {
            return View();
        }
    }
}
