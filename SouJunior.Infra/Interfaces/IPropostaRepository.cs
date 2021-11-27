using SouJunior.Domain.Entities;
using SouJunior.Domain.Filters;
using SouJunior.Infra.Dtos;
using System;
using System.Threading.Tasks;

namespace SouJunior.Infra.Interfaces
{
    public interface IPropostaRepository
    {
        Task<PaginationDto<PropostaListDto>> GetByFilter(PropostaFilter filter);
        Task<PropostaDto> GetById(Guid id);
    }
}
