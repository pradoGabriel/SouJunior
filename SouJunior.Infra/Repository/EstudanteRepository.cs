using Microsoft.EntityFrameworkCore;
using SouJunior.Infra.Data.Context;
using SouJunior.Infra.Dtos;
using SouJunior.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SouJunior.Infra.Repository
{
    public class EstudanteRepository : IEstudanteRepository
    {
        protected readonly MyContext _context;

        public EstudanteRepository(MyContext myContext)
        {
            _context = myContext;
        }

        public async Task<EstudanteDto> GetById(Guid id)
        {
            var result = await _context.Usuario
              .Include(_ => _.Estudante)
              .Include(_ => _.Endereco).FirstOrDefaultAsync(_ => _.Estudante.Id == id);

            return new EstudanteDto()
            {
                Id = result.Estudante.Id,
                Nome = result.Nome,
                Email = result.Email,
                Telefone = result.Telefone,
                Cpf = result.Estudante.Cpf,
                Periodo = result.Estudante.Periodo,
                ImagemPerfil = result.ImagemPerfil,
                Endereco = result.Endereco,
                Curso = result.Estudante.Curso,
                Instituicao = result.Estudante.Instituicao,
            };
        }
    }
}
