using Microsoft.AspNetCore.Mvc;
using SouJunior.Api.RequestExamples;
using SouJunior.Domain.Entities;
using SouJunior.Domain.Interfaces;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _ramoAtuacaoRepo.GetAll());
        }
    }
}
