using System;

namespace SouJunior.Domain.Entities
{
    public class CandidatoEntity : BaseEntity
    {
        public bool IsSelecionado { get; set; }
        public string LinkedinProfile { get; set; }
        public string InformacoesAdicionais { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
