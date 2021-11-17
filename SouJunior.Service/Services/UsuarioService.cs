using SouJunior.Domain.Entities;
using SouJunior.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SouJunior.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioEntity> GetById(Guid id)
        {
            var user = await _usuarioRepository.GetById(id);
            user.Senha = "";

            return user;
        }
    }
}
