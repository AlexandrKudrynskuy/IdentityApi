using BLL.Service;
using DLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Store_Identity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminBrandApiController : ControllerBase
    {
        private readonly BrandService _BrandService;
        private readonly UserManager<User> _userManager;

        public AdminBrandApiController(BrandService brandService, UserManager<User> userManager)
        {
            _BrandService = brandService;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetBrands")]
        public List<Brand> GetBrands()
        {
            return _BrandService.GetFromCondition(x => x.Id > 0).ToList();
        }

        [HttpPost]
        [Route("GetPhoto")]
        public string GetPhoto([FromBody] int id)
        {
            return _BrandService.GetFromCondition(x => x.Id==id).ToList().First().Photo;
        }




        [HttpPost]
        [Route("UpdateBrand")]
        public IActionResult UpdateBrand([FromBody] Brand brand)
        {
            try
            {
                _BrandService.Update(brand.Id, brand);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpPost]
        [Route("AddBrand")]
        public IActionResult AddBrand([FromBody] Brand brand)
        {
            try
            {
                _BrandService.Create(brand);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }



    }
}
