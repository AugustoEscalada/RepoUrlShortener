using Microsoft.AspNetCore.Mvc;
using ProyectoAcortadorURL.Data.Models;
using ProyectoAcortadorURL.Services.Interfaces;

namespace ProyectoAcortadorURL.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly IUserService _userService;
            public UserController(IUserService userRepository)
            {
                _userService = userRepository;
            }

            [HttpPost]
            public IActionResult CreateUser(UserForCreationDTO dto)
            {
                try
                {
                    _userService.Create(dto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
                return Created("Created", dto);
            }
        }
    }
