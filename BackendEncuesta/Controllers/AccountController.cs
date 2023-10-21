using AutoMapper;
using Azure.Identity;
using BackendEncuesta.DTO;
using BackendEncuesta.DTO.AccountDTO;
using BackendEncuesta.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Validations;
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
        private readonly IMapper _mapper;

        public AccountController(UserManager<UsersB> userManager, IConfiguration configuration, SignInManager<UsersB> signInManager, IMapper mapper )
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> Register(UserRegister userRegister)
        {
           
            var rutExists = await _userManager.Users.AnyAsync(u => u.rut == userRegister.rut);
            if (rutExists)
            {
                return BadRequest("El Rut ya está registrado");
            }

            var user = new UsersB { 
               
                UserName = userRegister.Email,
                Email = userRegister.Email,
                nombres = userRegister.nombres,
                apellidos = userRegister.apellidos,
                rut = userRegister.rut,
                fechaNacimiento = userRegister.fechaNacimiento,
                trabaja = userRegister.trabaja,
                ModalidadTrabajoId = userRegister.ModalidadTrabajoId,
                ComunaResidenciaId = userRegister.ComunaResidenciaId,
                EstadoId = userRegister.EstadoId,
                ComunaTrabajoId = userRegister.ComunaTrabajoId
            };
            var result = await _userManager.CreateAsync(user, userRegister.Password);
            var cred = _mapper.Map<UserCredentials>(userRegister);

            if (result.Succeeded)
            {
                //Construir Token
                return BuildToken(cred);
                   
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]

        public async Task<ActionResult<AuthenticationResponse>> Login(UserCredentials userCredentials)
        {
            var user = await _userManager.FindByNameAsync(userCredentials.Email);
            if (user.EstadoId == 1)
            {
                return BadRequest("Encuesta realizada");
            }
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
