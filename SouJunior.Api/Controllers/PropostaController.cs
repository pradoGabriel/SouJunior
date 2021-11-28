using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SouJunior.Domain.Entities;
using SouJunior.Domain.Filters;
using SouJunior.Infra.Interfaces;
using SouJunior.Service.Validators;
using System;
using System.Threading.Tasks;

namespace SouJunior.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class PropostaController : ControllerBase
    {
        private readonly IBaseService<PropostaEntity> _baseService;
        private readonly IPropostaRepository _repository;

        public PropostaController(IBaseService<PropostaEntity> baseService, IPropostaRepository repository)
        {
            _baseService = baseService;
            _repository = repository;
        }

        /// <summary>
        /// Método responsável pela criação de proposta
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        [Authorize]
        public IActionResult Create([FromBody] PropostaEntity proposta)
        {
            if (proposta == null)
                return BadRequest();

            return Ok(_baseService.Add<PropostaCreateValidator>(proposta).Id);
        }


        /// <summary>
        /// Método responsável pela edição de proposta
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}/")]
        [Authorize]
        public IActionResult Update(Guid id, [FromBody] PropostaEntity proposta)
        {
            if (proposta == null || id == null)
                return BadRequest();

            proposta.Id = id;
            return Ok(_baseService.Update<PropostaCreateValidator>(proposta).Id);
        }

        /// <summary>
        /// Método responsável pela exclusão de proposta
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpDelete("{id}/")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            if (id == null)
                return BadRequest();

            _baseService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Método responsável por obter lista de propostas paginada
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetByFilter")]
        [Authorize]
        public async Task<IActionResult> GetByFilter([FromQuery] PropostaFilter filter)
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
        /// Método responsável por obter uma proposta detalhada
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
