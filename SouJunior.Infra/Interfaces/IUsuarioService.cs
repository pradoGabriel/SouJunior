using SouJunior.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SouJunior.Infra.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioEntity> GetById(Guid id);
    }
}
