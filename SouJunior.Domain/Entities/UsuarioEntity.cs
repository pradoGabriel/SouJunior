namespace SouJunior.Domain.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string ImagemPerfil { get; set; }
        public EnderecoEntity Endereco { get; set; }
        public EmpresaJrEntity EmpresaJr { get; set; }
        public EmpreendedorEntity Empreendedor { get; set; }
        public EstudanteEntity Estudante { get; set; }
    }
}