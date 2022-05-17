using System;

namespace SouJunior.Domain.Entities
{
    public class PropostaEntity : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool? IsAceita { get; set; }
        public Guid EmpresaJrId { get; set; }
        public Guid EmpreendedorId { get; set; }
        public Guid EstudanteId { get; set; }
    }
}
