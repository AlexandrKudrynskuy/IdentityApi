using BLL.Service;
using DLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DLL;
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
        public  string userId;
        public CardApiController(ProductService productService, CardService cardService, UserManager<User> userManager)
        {
            _productService = productService;
            _cardService = cardService;
            _userManager = userManager;

        }

    
        [HttpPost]
        [Route("AddToCard")]
        public async Task<IActionResult> AddToCard([FromBody] int id)
        {
            userId = _userManager.Users.First(x => x.UserName == _userManager.GetUserId(HttpContext.User)).Id;


            var product = (await _productService.GetFromConditionAsync(x => x.Id == id)).First();
            if (product == null || userId == null)
            {
                return Problem();
            }

            var card = new Card { ProductId = product.Id, UserId = userId, StatusPaid = false };
            try
            {
                _cardService.Create(card);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }


        }

        [HttpGet]
        [Route("GetCountProduct")]
        public async Task<int> GetCountProduct()
        {
            userId = _userManager.Users.First(x => x.UserName == _userManager.GetUserId(HttpContext.User)).Id;
            var card = _cardService.GetFromCondition(x =>
                 x.UserId == userId && x.StatusPaid == false
            );

            return card.Count();
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<List<Card>> GetProduct()
        {
            userId = _userManager.Users.First(x => x.UserName == _userManager.GetUserId(HttpContext.User)).Id;

            var card = _cardService.GetFromCondition(x =>
            x.UserId == userId && x.StatusPaid == false
            ).ToList();

            //var products = new List<Product>();
            //foreach (var product in card)
            //{
            //    products.Add(product.Product);
            //}
            return card;
        }

        [HttpGet]
        [Route("History")]
        public async Task<List<Card>> History()
        {
            userId = _userManager.Users.First(x => x.UserName == _userManager.GetUserId(HttpContext.User)).Id;
            var card = _cardService.GetFromCondition(x =>
                 x.UserId == userId && x.StatusPaid == true
            ).ToList();
            return card;
        }


        [HttpPost]
        [Route("Bye")]
        public async Task<IActionResult> Bye([FromBody] int id)
        {
            try
            {
                _cardService.Update(id,new Card { StatusPaid=true});
                return Ok();

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> Remove([FromBody] int id)
        {
            try
            {
                _cardService.Delete(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
