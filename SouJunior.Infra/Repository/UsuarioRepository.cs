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
                .Include(_ => _.Empreendedor).ThenInclude(e => e.RamoAtuacao).AsNoTracking()
                .Include(_ => _.EmpresaJr).ThenInclude(ej => ej.RamoAtuacao).AsNoTracking()
                .Include(_ => _.Estudante).AsNoTracking()
                .Include(_ => _.Endereco).AsNoTracking()
                .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<Guid> Update(UsuarioEntity user)
        {
            var oldUser = await GetById(user.Id);

            if (oldUser.Empreendedor != null)
            {
                user.Empreendedor.Id = oldUser.Empreendedor.Id;
                _context.Entry(user.Empreendedor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            if (oldUser.EmpresaJr != null)
            {
                user.EmpresaJr.Id = oldUser.EmpresaJr.Id;
                _context.Entry(user.EmpresaJr).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            if (oldUser.Estudante != null)
            {
                user.Estudante.Id = oldUser.Estudante.Id;
                _context.Entry(user.Estudante).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            user.Endereco.Id = oldUser.Endereco.Id;
            _context.Entry(user.Endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
