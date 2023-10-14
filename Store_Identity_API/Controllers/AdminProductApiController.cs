using BLL.Service;
using DLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Store_Identity_API.Migrations;
using Store_Identity_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store_Identity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminProductApiController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ProductService _productService;

        public AdminProductApiController(UserManager<User> userManager, ProductService productService)
        {

            _userManager = userManager;
            _productService = productService;
        }

        [HttpPost]
        //[Route("AddProduct")]
        public IActionResult AddProduct([FromBody] Product value)
        {
            try
            {
                _productService.Create(value);
                return Ok();
            }
            catch(Exception ex)
                {
                return Problem(ex.Message);
            }
                
        }

    }
}
