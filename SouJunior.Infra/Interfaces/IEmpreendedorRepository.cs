using SouJunior.Infra.Dtos;
using System;
using System.Threading.Tasks;

namespace SouJunior.Infra.Interfaces
{
    public interface IEmpreendedorRepository
    {
        Task<EmpreendedorDto> GetById(Guid id);
    }
}
