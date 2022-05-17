using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SouJunior.Domain.Entities;
using SouJunior.Infra.Interfaces;
using SouJunior.Service.Validators;
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
    public class PostagemController : ControllerBase
    {
        private readonly IBaseService<PostagemEntity> _baseService;


        public PostagemController(IBaseService<PostagemEntity> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Método responsável pela criação de proposta
        /// </summary>
        /// <returns>Retorna código 200 em caso de sucesso</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        [Authorize]
        public IActionResult Create([FromBody] PostagemEntity postagem)
        {
            if (postagem == null)
                return BadRequest();

            return Ok(_baseService.Add<PostagemCreateValidator>(postagem).Id);
        }
    }
}
