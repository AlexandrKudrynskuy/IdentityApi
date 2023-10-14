using Microsoft.AspNetCore.Mvc;

namespace Store_Identity_API.Controllers
{
    public class AdminBrandController : Controller
    {
        public IActionResult AddBrand()
        {
            return View();
        }

        public IActionResult UpdateBrand()
        {
            return View();
        }
    }
}
