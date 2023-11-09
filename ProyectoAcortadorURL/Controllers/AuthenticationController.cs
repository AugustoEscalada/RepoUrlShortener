using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoAcortadorURL.Data.Models;
using ProyectoAcortadorURL.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoAcortadorURL.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public AuthenticationController(IConfiguration config, IUserService userService)
        {
            _config = config;
            this._userService = userService;

        }

        [HttpPost("authenticate")] 
        public IActionResult Autenticate(AuthDto AuthDto)
        {

            //Paso 1: Validamos las credenciales
            var user = _userService.ValidateUser(AuthDto); 

            if (user is null) 
                return Unauthorized();

            //Paso 2: Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:Key"])); 

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

        
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString())); 
            claimsForToken.Add(new Claim("name", user.Username));


            var jwtSecurityToken = new JwtSecurityToken( 
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler() 
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }
}
         
