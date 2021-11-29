using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SouJunior.Domain.Filters;
using SouJunior.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SouJunior.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpresaJrController : ControllerBase
    {
        private readonly IEmpresaJrRepository _repository;

        public EmpresaJrController(IEmpresaJrRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método responsável por obter lista de empresas juniores paginada
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetByFilter")]
        [Authorize]
        public async Task<IActionResult> GetByFilter([FromQuery] EmpresaJrFilter filter)
        {
            if (filter == null)
                return BadRequest();

            var result = await _repository.GetByFilter(filter);

            return Ok(new
            {
                result.Dados,
                result.TotalPages,
                result.HasNextPage,
                result.HasPreviousPage,
                result.PageIndex,
                result.TotalItems
            });
        }

        /// <summary>
        /// Método responsável por obter uma empresa junior
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
