using Microsoft.AspNetCore.Mvc;
using SouJunior.Domain.Entities;
using Swashbuckle.AspNetCore.Filters;
using SouJunior.Service.Validators;
using SouJunior.Api.RequestExamples;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using SouJunior.Infra.Interfaces;

namespace SouJunior.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IBaseService<UsuarioEntity> _baseService;
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IBaseService<UsuarioEntity> baseService, IUsuarioService usuarioService, IUsuarioRepository usuarioRepository)
        {
            _baseService = baseService;
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Método responsável pela criação de usuário
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [SwaggerRequestExample(typeof(UsuarioEntity), typeof(CreateUsuarioExample))]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] UsuarioEntity usuario)
        {
            if (usuario == null)
                return BadRequest();

            return Ok(_baseService.Add<UsuarioCreateValidator>(usuario).Id);
        }

        /// <summary>
        /// Método responsável pela edição de um usuário
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [SwaggerRequestExample(typeof(UsuarioEntity), typeof(CreateUsuarioExample))]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}/")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UsuarioEntity usuario)
        {
            if (usuario == null || id == null)
                return BadRequest();

            usuario.Id = id;
            return Ok(await _usuarioRepository.Update(usuario));
        }

        /// <summary>
        /// Método por obter um usuario
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("{id}/")]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            if (id == null)
                return BadRequest();

            return Ok(await _usuarioService.GetById(id));
        }
    }
}
