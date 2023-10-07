using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store_Identity_API.Context;
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
        private readonly Store_Identity_APIContext _context;

        public AdminProductApiController(Store_Identity_APIContext context)
        {
            _context = context;
        }

        // GET: api/<AdminProductApiController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var rez= await _context.Products.ToListAsync();
            return  rez;
        }
        // GET api/<AdminProductApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminProductApiController>
        [HttpPost]
        [Route("post")]
        public  void Post([FromBody] Product value)
        {
            _context.Products.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<AdminProductApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
        }

        // DELETE api/<AdminProductApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
