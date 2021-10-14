using Microsoft.EntityFrameworkCore;
using SouJunior.Domain.Entities;
using SouJunior.Domain.Interfaces;
using SouJunior.Infra.Data.Context;
using System.Threading.Tasks;

namespace SouJunior.Infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly MyContext _context;

        public UsuarioRepository(MyContext myContext)
        {
            _context = myContext;
        }

        public async Task<UsuarioEntity> FindUsuario(string email)
        {
            return await _context.Usuario.FirstOrDefaultAsync(_ => _.Email == email);
        }
    }
}
