using BLL.Service;
using DLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Store_Identity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CardApiController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly CardService _cardService;
        private readonly UserManager<User> _userManager;

        public CardApiController(ProductService productService, CardService cardService, UserManager<User> userManager)
        {
            _productService = productService;
            _cardService = cardService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("AddToCard")]
        public async Task<IActionResult> AddToCard([FromBody]int id)
        {
            var userId= await _userManager.GetUserIdAsync(new User());
            var product = (await _productService.GetFromConditionAsync(x=>x.Id==id)).First();
            if (product == null || userId == null)
            {
                return Problem();
            }
             _cardService.CreateAsync(new Card { ProductId= product.Id, UserId=userId});

            return Ok();
        
        }
    }
}
