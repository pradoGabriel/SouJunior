using SouJunior.Domain.Filters;
using SouJunior.Infra.Dtos;
using System;
using System.Threading.Tasks;

namespace SouJunior.Infra.Interfaces
{
    public interface IEmpresaJrRepository
    {
        Task<PaginationDto<EmpresaJrDto>> GetByFilter(EmpresaJrFilter filter);
        Task<EmpresaJrDto> GetById(Guid id);
    }
}
