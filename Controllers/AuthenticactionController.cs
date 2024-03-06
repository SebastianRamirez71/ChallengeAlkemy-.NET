using challange_disney.DTO.User;
using challange_disney.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace challange_disney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticactionController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticactionController> _logger;

        public AuthenticactionController(IAuthService service, ILogger<AuthenticactionController> logger)
        {
            _authService = service;
            _logger = logger;

        }

        [HttpPost("Register")]
        public IActionResult Register(UserRegisterDTO user)
        {
            string response = string.Empty;
            try
            {
                response = _authService.Register(user);
                if (response == "Ingrese un usuario" || response == "Usuario existente")
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("CrearUsuario", ex);
                return BadRequest($"{ex.Message}");
            }

            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserInfo user)
        {
            string response = string.Empty;
            try
            {
                response = _authService.Login(user);
                if (string.IsNullOrEmpty(response))
                    return NotFound("email/contraseña incorrecta");
            }
            catch (Exception ex)
            {
                _logger.LogError("Login", ex);
                return BadRequest($"{ex.Message}");
            }

            return Ok(response);
        }
    }
}
