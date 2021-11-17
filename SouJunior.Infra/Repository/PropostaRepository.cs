using Microsoft.EntityFrameworkCore;
using SouJunior.Domain.Entities;
using SouJunior.Domain.Filters;
using SouJunior.Infra.Data.Context;
using SouJunior.Infra.Dtos;
using SouJunior.Infra.Helpers;
using SouJunior.Infra.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SouJunior.Infra.Repository
{
    public class PropostaRepository : IPropostaRepository
    {
        protected readonly MyContext _context;

        public PropostaRepository(MyContext myContext)
        {
            _context = myContext;
        }

        public async Task<PaginationDto<PropostaEntity>> GetByFilter(PropostaFilter filter)
        {
            IQueryable<PropostaEntity> query = _context.Proposta.AsQueryable();

            if (filter.EmpreendedorId != null)
                query = query.Where(_ => _.EmpreendedorId == filter.EmpreendedorId);

            if (filter.EmpresaJrId != null)
                query = query.Where(_ => _.EmpreendedorId == filter.EmpresaJrId);

            var result = await PaginationHelper<PropostaEntity>.CreateAsync(query, filter.PageIndex, filter.PageSize);

            var propostas = result.Select(_ => new PropostaEntity()
            {
                Id = _.Id,
                EmpreendedorId = _.EmpreendedorId,
                EmpresaJrId = _.EmpresaJrId,
                Titulo = _.Titulo,
                Descricao = _.Descricao,
                DataCriacao = _.DataCriacao,

            }).ToList();

            return new PaginationDto<PropostaEntity>()
            {
                Dados = propostas,
                TotalPages = result.TotalPages,
                PageIndex = result.PageIndex,
                HasNextPage = result.HasNextPage,
                HasPreviousPage = result.HasPreviousPage
            };
        }
    }
}
