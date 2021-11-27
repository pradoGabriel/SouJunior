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
        public Guid EmpresaJrId { get; set; }
        public Guid EmpreendedorId { get; set; }
        public string NomeFantasiaEmpreendedor { get; set; }
        public string ImagemEmpreendedor { get; set; }
        public string NomeFantasiaEmpresaJr { get; set; }
        public string ImagemEmpresaJr { get; set; }
    }
}
