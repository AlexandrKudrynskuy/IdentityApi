using Microsoft.AspNetCore.Mvc;

namespace Store_Identity_API.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
