using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SouJunior.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SouJunior.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpreendedorController : ControllerBase
    {
        private readonly IEmpreendedorRepository _repository;

        public EmpreendedorController(IEmpreendedorRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método responsável por obter um empreendedor
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

            return Ok(await _repository.GetById(id));
        }
    }
}
