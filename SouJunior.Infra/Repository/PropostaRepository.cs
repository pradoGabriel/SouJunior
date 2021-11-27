using Microsoft.EntityFrameworkCore;
using SouJunior.Domain.Entities;
using SouJunior.Domain.Filters;
using SouJunior.Infra.Data.Context;
using SouJunior.Infra.Dtos;
using SouJunior.Infra.Helpers;
using SouJunior.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouJunior.Infra.Repository
{
    public class PropostaRepository : IPropostaRepository
    {
        protected readonly MyContext _context;
        protected readonly IEmpresaJrRepository _empresaJrRepository;
        protected readonly IEmpreendedorRepository _empreendedorRepository;

        public PropostaRepository(MyContext myContext, IEmpresaJrRepository empresaJr, IEmpreendedorRepository empreendedorRepository)
        {
            _context = myContext;
            _empreendedorRepository = empreendedorRepository;
            _empresaJrRepository = empresaJr;
        }

        public async Task<PaginationDto<PropostaListDto>> GetByFilter(PropostaFilter filter)
        {
            IQueryable<PropostaEntity> query = _context.Proposta.AsQueryable();

            if (filter.EmpreendedorId != null)
                query = query.Where(_ => _.EmpreendedorId == filter.EmpreendedorId);

            if (filter.EmpresaJrId != null)
                query = query.Where(_ => _.EmpreendedorId == filter.EmpresaJrId);

            if (filter.IsAceita != null)
                query = query.Where(_ => _.IsAceita == filter.IsAceita);

            var result = await PaginationHelper<PropostaEntity>.CreateAsync(query, filter.PageIndex, filter.PageSize);

            var propostas = result.Select(async _ => new PropostaListDto()
            {
                Id = _.Id,
                EmpreendedorId = _.EmpreendedorId,
                EmpresaJrId = _.EmpresaJrId,
                Titulo = _.Titulo,
                IsAceita = _.IsAceita,
                Descricao = _.Descricao,
                DataCriacao = _.DataCriacao,
                NomeFantasiaEmpreendedor = (await _empreendedorRepository.GetById(_.EmpreendedorId)).NomeFantasia,
                ImagemEmpreendedor = (await _empreendedorRepository.GetById(_.EmpreendedorId)).ImagemPerfil,
                NomeFantasiaEmpresaJr = (await _empresaJrRepository.GetById(_.EmpresaJrId)).NomeFantasia,
                ImagemEmpresaJr = (await _empresaJrRepository.GetById(_.EmpresaJrId)).ImagemPerfil
            }).ToList();

            var list = new List<PropostaListDto>();

            propostas.ForEach(x => list.Add(x.Result));

            return new PaginationDto<PropostaListDto>()
            {
                Dados = list,
                TotalPages = result.TotalPages,
                PageIndex = result.PageIndex,
                HasNextPage = result.HasNextPage,
                HasPreviousPage = result.HasPreviousPage,
                TotalItems = result.TotalItems
            };
        }

        public async Task<PropostaDto> GetById(Guid id)
        {
            var result = await _context.Proposta.FirstOrDefaultAsync(_ => _.Id == id);

            return new PropostaDto()
            {
                Id = result.Id,
                IsAceita = result.IsAceita,
                Titulo = result.Titulo,
                Descricao = result.Descricao,
                DataCriacao = result.DataCriacao,
                Empreendedor = await _empreendedorRepository.GetById(result.EmpreendedorId),
                EmpresaJr = await _empresaJrRepository.GetById(result.EmpresaJrId)
            };
        }
    }
}
