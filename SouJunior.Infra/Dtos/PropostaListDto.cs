using System;

namespace SouJunior.Infra.Dtos
{
    public class PropostaListDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool? IsAceita { get; set; }
        public Guid? EmpresaJrId { get; set; }
        public Guid? EmpreendedorId { get; set; }
        public string NomeFantasiaEmpreendedor { get; set; }
        public string ImagemEmpreendedor { get; set; }
        public string EmailEmpreendedor { get; set; }
        public string TelefoneEmpreendedor { get; set; }
        public string NomeFantasiaEmpresaJr { get; set; }
        public string ImagemEmpresaJr { get; set; }
        public string EmailEmpresaJr { get; set; }
        public string TelefoneEmpresaJr { get; set; }
        public string NomeEstudante { get; set; }
        public string ImagemEstudante { get; set; }
        public string EmailEstudante { get; set; }
        public string TelefoneEstudante { get; set; }
        public string PerfilLinkedin { get; set; }
    }
}
