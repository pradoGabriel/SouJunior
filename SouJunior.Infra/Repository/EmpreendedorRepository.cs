using Microsoft.EntityFrameworkCore;
using SouJunior.Infra.Data.Context;
using SouJunior.Infra.Dtos;
using SouJunior.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SouJunior.Infra.Repository
{
    public class EmpreendedorRepository : IEmpreendedorRepository
    {
        protected readonly MyContext _context;

        public EmpreendedorRepository(MyContext myContext)
        {
            _context = myContext;
        }

        public async Task<EmpreendedorDto> GetById(Guid id)
        {
            var result = await _context.Usuario
                .Include(_ => _.Empreendedor).ThenInclude(e => e.RamoAtuacao)
                .Include(_ => _.Endereco).FirstOrDefaultAsync(_ => _.Empreendedor.Id == id);

            return new EmpreendedorDto()
            {
                Id = result.Empreendedor.Id,
                NomeFantasia = result.Empreendedor.NomeFantasia,
                Email = result.Email,
                Telefone = result.Telefone,
                RamoAtuacao = result.Empreendedor.RamoAtuacao.Descricao,
                RazaoSocial = result.Empreendedor.RazaoSocial,
                Cnpj = result.Empreendedor.Cnpj,
                Descricao = result.Empreendedor.Descricao,
                ImagemPerfil = result.ImagemPerfil,
                Endereco = result.Endereco,
                DataCriacao = result.Empreendedor.DataCriacao
            };
        }
    }
}
