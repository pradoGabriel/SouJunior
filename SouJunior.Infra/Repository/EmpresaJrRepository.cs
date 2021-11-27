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

    public class EmpresaJrRepository : IEmpresaJrRepository
    {
        protected readonly MyContext _context;

        public EmpresaJrRepository(MyContext myContext)
        {
            _context = myContext;
        }

        public async Task<PaginationDto<EmpresaJrDto>> GetByFilter(EmpresaJrFilter filter)
        {
            IQueryable<UsuarioEntity> query = _context.Usuario
                .Include(_ => _.EmpresaJr).ThenInclude(e => e.RamoAtuacao)
                .Include(_ => _.Endereco).Where(_ => _.EmpresaJr != null);

            if (!string.IsNullOrEmpty(filter.NomeFantasia))
                query = query.Where(_ => _.EmpresaJr.NomeFantasia.Contains(filter.NomeFantasia));

            if (!string.IsNullOrEmpty(filter.RamoAtuacao))
                query = query.Where(_ => _.EmpresaJr.RamoAtuacao.Descricao.Contains(filter.RamoAtuacao));

            var result = await PaginationHelper<UsuarioEntity>.CreateAsync(query, filter.PageIndex, filter.PageSize);

            var empresas = result.Select(_ => new EmpresaJrDto()
            {
                Id = _.EmpresaJr.Id,
                NomeFantasia = _.EmpresaJr.NomeFantasia,
                Email = _.Email,
                Telefone = _.Telefone,
                RamoAtuacao = _.EmpresaJr.RamoAtuacao.Descricao,
                RazaoSocial = _.EmpresaJr.RazaoSocial,
                Cnpj = _.EmpresaJr.Cnpj,
                Descricao = _.EmpresaJr.Descricao,
                ImagemPerfil = _.ImagemPerfil,
                Endereco = _.Endereco,
                DataCriacao = _.EmpresaJr.DataCriacao
            }).ToList();

            return new PaginationDto<EmpresaJrDto>() { 
                Dados = empresas, 
                TotalPages = result.TotalPages, 
                PageIndex = result.PageIndex,
                HasNextPage = result.HasNextPage,
                HasPreviousPage = result.HasPreviousPage,
                TotalItems = result.TotalItems
            };
        }

        public async Task<EmpresaJrDto> GetById(Guid id)
        {
            var result = await _context.Usuario
                .Include(_ => _.EmpresaJr).ThenInclude(e => e.RamoAtuacao)
                .Include(_ => _.Endereco).FirstOrDefaultAsync(_ => _.EmpresaJr.Id == id);
          
            return new EmpresaJrDto()
            {
                Id = result.EmpresaJr.Id,
                NomeFantasia = result.EmpresaJr.NomeFantasia,
                Email = result.Email,
                Telefone = result.Telefone,
                RamoAtuacao = result.EmpresaJr.RamoAtuacao.Descricao,
                RazaoSocial = result.EmpresaJr.RazaoSocial,
                Cnpj = result.EmpresaJr.Cnpj,
                Descricao = result.EmpresaJr.Descricao,
                ImagemPerfil = result.ImagemPerfil,
                Endereco = result.Endereco,
                DataCriacao = result.EmpresaJr.DataCriacao
            };
        }
    }
}
