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

    public class AdminProductApiController : ControllerBase
    {
        private readonly DLL.Store_Identity_APIContext _context;
        private readonly UserManager<DLL.Models.User> _userManager;

        public AdminProductApiController(DLL.Store_Identity_APIContext context, UserManager<DLL.Models.User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: api/<AdminProductApiController>
        [HttpGet]
        public async Task<IEnumerable<DLL.Models.Product>> Get()
        {
            var rez = await _context.Products.ToListAsync();
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
        //[Route("post")]
        [Authorize]
        public async void Post([FromBody] DLL.Models.Product value)
        {
          
            _context.Products.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<AdminProductApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DLL.Models.Product value)
        {
        }

        // DELETE api/<AdminProductApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
