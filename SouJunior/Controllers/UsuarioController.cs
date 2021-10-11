using Microsoft.AspNetCore.Mvc;
using SouJunior.Domain.Entities;
using SouJunior.Domain.Interfaces;
using SouJunior.Service.Validators;

namespace SouJunior.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IBaseService<UsuarioEntity> _usuarioService;

        public UsuarioController(IBaseService<UsuarioEntity> usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] UsuarioEntity user)
        {
            if (user == null)
                return NotFound();

            return Ok(_usuarioService.Add<UsuarioCreateValidator>(user).Id);
        }
    }
}
