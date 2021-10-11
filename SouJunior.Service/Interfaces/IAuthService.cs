using SouJunior.Domain.Entities;
using SouJunior.Service.Dtos;
using System.Threading.Tasks;

namespace SouJunior.Service.Interfaces
{
    public interface IAuthService
    {
        Task<UsuarioEntity> AuthenticateUser(LoginDto login);
    }
}
