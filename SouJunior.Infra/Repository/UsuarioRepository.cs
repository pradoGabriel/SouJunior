using Microsoft.EntityFrameworkCore;
using SouJunior.Domain.Entities;
using SouJunior.Infra.Data.Context;
using SouJunior.Infra.Interfaces;
using System;
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

        public async Task<UsuarioEntity> FindUsuario(string email, string senha)
        {
            return await _context.Usuario
                .Include(_ => _.Empreendedor).ThenInclude(e => e.RamoAtuacao)
                .Include(_ => _.EmpresaJr).ThenInclude(ej => ej.RamoAtuacao)
                .Include(_ => _.Estudante)
                .Include(_ => _.Endereco)
                .FirstOrDefaultAsync(_ => _.Email.ToLower() == email.ToLower() && _.Senha == senha);
        }

        public async Task<UsuarioEntity> GetById(Guid id)
        {
            return await _context.Usuario
                .Include(_ => _.Empreendedor).ThenInclude(e => e.RamoAtuacao)
                .Include(_ => _.EmpresaJr).ThenInclude(ej => ej.RamoAtuacao)
                .Include(_ => _.Estudante)
                .Include(_ => _.Endereco)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}
