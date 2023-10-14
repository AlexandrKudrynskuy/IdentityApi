using BLL.Service;
using DLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Store_Identity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandApiController : ControllerBase
    {
        private readonly BrandService _brandService;

        public BrandApiController(BrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        [Route("GetBrand")]
        public List<Brand> GetBrand()
        {
            return _brandService.GetFromCondition(x => x.Id > 0).ToList();
        }
    }
}
