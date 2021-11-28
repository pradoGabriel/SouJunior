using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SouJunior.Infra.Dtos;
using SouJunior.Infra.Interfaces;
using SouJunior.Service.Services;
using System.Threading.Tasks;

namespace SouJunior.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthenticationController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Método responsável por realizar login
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (login == null)
                return NotFound();

            var user = await _usuarioRepository.FindUsuario(login.Email, login.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = AuthService.GenerateToken(user);
            user.Senha = "";

            return Ok(new
            {
                usuario = user,
                token = token
            });
        }
    }
}
