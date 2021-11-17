using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SouJunior.Api.RequestExamples;
using SouJunior.Domain.Entities;
using SouJunior.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SouJunior.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class RamoAtuacaoController : ControllerBase
    {
        private readonly IRamoAtuacaoRepository _ramoAtuacaoRepo;

        public RamoAtuacaoController(IRamoAtuacaoRepository ramoAtuacaoRepo)
        {
            _ramoAtuacaoRepo = ramoAtuacaoRepo;
        }

        /// <summary>
        /// Método responsável por obter lista de ramos de atuação
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [ProducesResponseType(typeof(GetAllRamoAtuacaoExample), 200)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetAll")]
        [AllowAnonymous]
        //[Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _ramoAtuacaoRepo.GetAll());
        }

        /// <summary>
        /// Método responsável por obter um ramo de atuação
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [ProducesResponseType(typeof(GetAllRamoAtuacaoExample), 200)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("{id}/")]
        [AllowAnonymous]
        //[Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _ramoAtuacaoRepo.GetById(id));
        }
    }
}
