using SouJunior.Domain.Entities;
using System.Threading.Tasks;

namespace SouJunior.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity> FindUsuario(string email);
    }
}
