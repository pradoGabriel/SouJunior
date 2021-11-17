using SouJunior.Domain.Entities;
using SouJunior.Domain.Filters;
using SouJunior.Infra.Dtos;
using System.Threading.Tasks;

namespace SouJunior.Infra.Interfaces
{
    public interface IPropostaRepository
    {
        Task<PaginationDto<PropostaEntity>> GetByFilter(PropostaFilter filter);
    }
}
