using SouJunior.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SouJunior.Infra.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity> FindUsuario(string email, string senha);
        Task<UsuarioEntity> GetById(Guid id);
        Task<Guid> Update(UsuarioEntity user);
    }
}
