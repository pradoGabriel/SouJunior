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
        protected readonly IEstudanteRepository _estudanteRepository;
        protected readonly IPostagemRepository _postagemRepository;

        public PropostaRepository(
            MyContext myContext,
            IEmpresaJrRepository empresaJr,
            IEmpreendedorRepository empreendedorRepository,
            IEstudanteRepository estudanteRepository,
            IPostagemRepository postagemRepository)
        {
            _context = myContext;
            _empreendedorRepository = empreendedorRepository;
            _empresaJrRepository = empresaJr;
            _estudanteRepository = estudanteRepository;
            _postagemRepository = postagemRepository;
        }

        public async Task<PaginationDto<PropostaListDto>> GetByFilter(PropostaFilter filter)
        {
            IQueryable<PropostaEntity> query = _context.Proposta.AsQueryable();

            if (filter.EmpreendedorId != null)
                query = query.Where(_ => _.EmpreendedorId == filter.EmpreendedorId);

            if (filter.EmpresaJrId != null)
                query = query.Where(_ => _.EmpresaJrId == filter.EmpresaJrId);

            if (filter.EstudanteId != null)
                query = query.Where(_ => _.EstudanteId == filter.EstudanteId);

            if (filter.IsAceita != null)
                query = query.Where(_ => _.IsAceita == filter.IsAceita);

            var result = await PaginationHelper<PropostaEntity>.CreateAsync(query, filter.PageIndex, filter.PageSize);

            var list = new List<PropostaListDto>();

            foreach(var proposta in result)
            {
                var item = new PropostaListDto()
                {
                    Id = proposta.Id,
                    EmpreendedorId = proposta.EmpreendedorId,
                    EmpresaJrId = proposta.EmpresaJrId,
                    Titulo = proposta.Titulo,
                    IsAceita = proposta.IsAceita,
                    Descricao = proposta.Descricao,
                    DataCriacao = proposta.DataCriacao,
                    PerfilLinkedin = proposta.PerfilLinkedin
                };

                if (proposta.EmpreendedorId != null && proposta.EmpreendedorId != new Guid())
                {
                    var empreendedor = await _empreendedorRepository.GetById(proposta.EmpreendedorId);
                    item.NomeFantasiaEmpreendedor = empreendedor.NomeFantasia;
                    item.ImagemEmpreendedor = empreendedor.ImagemPerfil;
                    item.EmailEmpreendedor = empreendedor.Email;
                    item.TelefoneEmpreendedor = empreendedor.Telefone;
                }

                if (proposta.EmpresaJrId != null && proposta.EmpresaJrId != new Guid())
                {
                    var empresaJr = await _empresaJrRepository.GetById(proposta.EmpresaJrId);
                    item.NomeFantasiaEmpresaJr = empresaJr.NomeFantasia;
                    item.ImagemEmpresaJr = empresaJr.ImagemPerfil;
                    item.EmailEmpresaJr = empresaJr.Email;
                    item.TelefoneEmpresaJr = empresaJr.Telefone;
                }

                if (proposta.EstudanteId != null && proposta.EstudanteId != new Guid())
                {
                    var estudante = await _estudanteRepository.GetById(proposta.EstudanteId);
                    item.NomeEstudante = estudante.Nome;
                    item.ImagemEstudante = estudante.ImagemPerfil;
                    item.EmailEstudante = estudante.Email;
                    item.TelefoneEstudante = estudante.Telefone;
                }


                list.Add(item);
            }

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

            var estudante = new EstudanteDto();
            var empreendedor = new EmpreendedorDto();
            var empresaJr = new EmpresaJrDto();

            if (result.EmpreendedorId != null && result.EmpreendedorId != new Guid())
                empreendedor = await _empreendedorRepository.GetById(result.EmpreendedorId);

            if (result.EmpresaJrId != null && result.EmpresaJrId != new Guid())
                empresaJr = await _empresaJrRepository.GetById(result.EmpresaJrId);

            if (result.EstudanteId != null && result.EstudanteId != new Guid())
                estudante = await _estudanteRepository.GetById(result.EstudanteId);

            return new PropostaDto()
            {
                Id = result.Id,
                IsAceita = result.IsAceita,
                Titulo = result.Titulo,
                Descricao = result.Descricao,
                DataCriacao = result.DataCriacao,
                Empreendedor = empreendedor,
                EmpresaJr = empresaJr,
                Estudante = estudante,
                Postagens = _postagemRepository.FilterByProposta(id),
                PerfilLinkedin = result.PerfilLinkedin
            };
        }
    }
}
