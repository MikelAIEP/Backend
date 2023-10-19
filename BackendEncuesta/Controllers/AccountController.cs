using Azure.Identity;
using BackendEncuesta.DTO.AccountDTO;
using BackendEncuesta.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendEncuesta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UsersB> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<UsersB> _signInManager;

        public AccountController(UserManager<UsersB> userManager, IConfiguration configuration, SignInManager<UsersB> signInManager )
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> Register(UserCredentials userCredentials)
        {
            var user = new UsersB { 
               
                UserName = userCredentials.Email,
                Email = userCredentials.Email,
                nombres = userCredentials.nombres,
                apellidos = userCredentials.apellidos,
                rut = userCredentials.rut,
                trabaja = userCredentials.trabaja,
                ModalidadTrabajoId = userCredentials.ModalidadTrabajoId,
                ComunaResidenciaId = userCredentials.ComunaResidenciaId,
                EstadoId = userCredentials.EstadoId,
                ComunaTrabajoId = userCredentials.ComunaTrabajoId
            };
            var result = await _userManager.CreateAsync(user, userCredentials.Password);
            if (result.Succeeded)
            {
                //Construir Token
                return BuildToken(userCredentials);
                   
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]

        public async Task<ActionResult<AuthenticationResponse>> Login(UserCredentials userCredentials)
        {
            var result = await _signInManager.PasswordSignInAsync(userCredentials.Email, userCredentials.Password, isPersistent:false, lockoutOnFailure: false  );
            if (result.Succeeded)
            {
                //Construir el Token
                return BuildToken(userCredentials);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }

        private AuthenticationResponse BuildToken(UserCredentials userCredentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", userCredentials.Email),
                new Claim("Otra info", " que se necesite enviar de vuelta")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwtkey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(60);
            var securityToken = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                
                );
            return new AuthenticationResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };
        }


    }
}
