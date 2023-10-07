using Microsoft.AspNetCore.Mvc;

namespace Store_Identity_API.Controllers
{
    public class AdminProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
