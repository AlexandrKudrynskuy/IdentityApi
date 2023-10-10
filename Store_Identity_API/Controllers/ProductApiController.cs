using BLL.Service;
using DLL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store_Identity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        // GET: api/<ProductApiController>
        private readonly ProductService _productService;

        public ProductApiController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var rez = await _productService.GetFromConditionAsync(x => x.Id > 0);
            return rez;
        }

        // GET api/<ProductApiController>/5
        //[HttpGet("{id}")]
        //public async Task<Product> Get(int id)
        //{
        //     return (await _productService.GetFromConditionAsync(x => x.Id == id)).First();
            
        //}

    }
}
