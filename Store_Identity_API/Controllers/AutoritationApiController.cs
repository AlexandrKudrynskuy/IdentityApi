using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using Store_Identity_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Store_Identity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoritationApiController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _userRoles;
        private readonly UserManager<DLL.Models.User> _userManager;
        private readonly IConfiguration _configuration;

        public AutoritationApiController(RoleManager<IdentityRole> userRoles, UserManager<DLL.Models.User> userManager, IConfiguration configuration)
        {
            _userRoles = userRoles;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Registration([FromBody] RegisterModel model)
        {

            var userExist = await _userManager.FindByNameAsync(model.Name);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", "User AlReady exist"));
            }
            var user = new DLL.Models.User
            {
                UserName = model.Name,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", "Server Error"));
            }

            return Ok(StatusCode(StatusCodes.Status200OK, new Response("Register User", "Ok")));
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var userExist = await _userManager.FindByNameAsync(model.Name);
            if (userExist == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new Response("Error", "Login not correct"));
            }
            var result = await _userManager.CheckPasswordAsync(userExist, model.Password);
            if (result == false)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new Response("Error", "Password not correct"));
            }
            var userRole = await _userManager.GetRolesAsync(userExist);
            var authClaim = new List<Claim>{
              new Claim(ClaimTypes.NameIdentifier, userExist.UserName)
            };

            foreach (var role in userRole)
            {
                authClaim.Add(new Claim(ClaimTypes.Role, role));
            }
            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var d = DateTime.Now.AddHours(3);

                var token = new JwtSecurityToken
                (
                 issuer: _configuration["JWT:ValidIssuier"],
                 audience: _configuration["JWT:ValidAudience"],
                 expires: DateTime.Now.AddHours(6),
                 claims: authClaim,
                 signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
                 );
          
                 var res = new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo };

                return Ok(res);
               }
    }


}
