using Azure.Identity;
using BackendEncuesta.DTO.AccountDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackendEncuesta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> Register(UserCredentials userCredentials)
        {
            var user = new IdentityUser { UserName = userCredentials.Email, Email = userCredentials.Email };
            var result = await _userManager.CreateAsync(user, userCredentials.Password);
            if (result.Succeeded)
            {
                //Construir Token
                   
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        private AuthenticationResponse BuildToken(UserCredentials userCredentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", userCredentials.Email),
                new Claim("Otra info", " que se necesite enviar de vuelta")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Llave secreta para validar el token"));
        }


    }
}
