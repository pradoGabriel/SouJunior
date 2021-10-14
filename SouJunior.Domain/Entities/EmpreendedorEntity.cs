using System;

namespace SouJunior.Domain.Entities
{
    public class EmpreendedorEntity : BaseEntity
    {
        public string Cnpj { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public int RamoAtuacaoId { get; set; }
        public RamoAtuacaoEntity RamoAtuacao { get; set; }
    }
}
