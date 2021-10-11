using Microsoft.EntityFrameworkCore;
using SouJunior.Domain.Entities;

namespace SouJunior.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<AvaliacaoEntity> Avaliacao { get; set; }
        public DbSet<CandidatoEntity> Candidato { get; set; }
        public DbSet<EmpreendedorEntity> Empreendedor { get; set; }
        public DbSet<EmpresaJrEntity> EmpresaJr { get; set; }
        public DbSet<EnderecoEntity> Endereco { get; set; }
        public DbSet<EstudanteEntity> Estudante { get; set; }
        public DbSet<PropostaEntity> Proposta { get; set; }
        public DbSet<RamoAtuacaoEntity> RamoAtuacao { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
    }
}
