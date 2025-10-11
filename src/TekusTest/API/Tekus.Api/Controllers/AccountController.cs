using Microsoft.AspNetCore.Mvc;
using Tekus.Application.Contracts.Identity;
using Tekus.Application.Exceptions;
using Tekus.Application.Models.Identity;

namespace Tekus.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Inicia sesión y devuelve un token de autenticación.
        /// </summary>
        /// <param name="request">Datos de autenticación</param>
        /// <returns>Token de acceso</returns>
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _authService.Login(request);

                return result != null ? Ok(result) : BadRequest("Nombre de usuario o contraseña no válidos");
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
