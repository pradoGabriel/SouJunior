using System;

namespace SouJunior.Domain.Entities
{
    public class AvaliacaoEntity : BaseEntity
    {
        public int Nota { get; set; }
        public string Comentario { get; set; }
        public Guid PropostaId { get; set; }
    }
}
