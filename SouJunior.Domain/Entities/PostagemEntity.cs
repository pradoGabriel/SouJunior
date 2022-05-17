using System;

namespace SouJunior.Domain.Entities
{
    public class PostagemEntity : BaseEntity
    {
        public Guid PropostaId { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataHora { get; set; }
        public string NomeUsuario { get; set; }
    }
}
