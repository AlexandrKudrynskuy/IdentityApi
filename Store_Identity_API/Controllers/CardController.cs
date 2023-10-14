using Microsoft.AspNetCore.Mvc;

namespace Store_Identity_API.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Buy()
        {
            return View();
        }

    }
}
