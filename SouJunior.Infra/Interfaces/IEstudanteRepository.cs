using SouJunior.Infra.Dtos;
using System;
using System.Threading.Tasks;

namespace SouJunior.Infra.Interfaces
{
    public interface IEstudanteRepository
    {
        Task<EstudanteDto> GetById(Guid id);
    }
}
