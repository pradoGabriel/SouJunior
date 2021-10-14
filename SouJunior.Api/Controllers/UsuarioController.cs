using Microsoft.AspNetCore.Mvc;
using SouJunior.Domain.Entities;
using SouJunior.Domain.Interfaces;
using Swashbuckle.AspNetCore.Filters;
using SouJunior.Service.Validators;
using SouJunior.Api.RequestExamples;

namespace SouJunior.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IBaseService<UsuarioEntity> _usuarioService;

        public UsuarioController(IBaseService<UsuarioEntity> usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Método responsável pela criação de usuário
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [SwaggerRequestExample(typeof(UsuarioEntity), typeof(CreateUsuarioExample))]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] UsuarioEntity usuario)
        {
            if (usuario == null)
                return BadRequest();

            return Ok(_usuarioService.Add<UsuarioCreateValidator>(usuario).Id);
        }
    }
}
