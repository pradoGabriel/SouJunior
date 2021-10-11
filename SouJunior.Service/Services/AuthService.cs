using SouJunior.Domain.Entities;
using SouJunior.Domain.Interfaces;
using SouJunior.Service.Dtos;
using SouJunior.Service.Interfaces;
using System.Threading.Tasks;

namespace SouJunior.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioEntity> AuthenticateUser(LoginDto login)
        {
            login.Email = login.Email.Trim().ToLower();
            var usuario = await _usuarioRepository.FindUsuario(login.Email);
            if (usuario == null)
            {
                return null;
            }

            if (BCrypt.Net.BCrypt.Verify(login.Senha, usuario.Senha))
            {
                return usuario;
            } 
            return null;
        }
    }
}
