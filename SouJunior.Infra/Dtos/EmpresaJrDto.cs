using SouJunior.Domain.Entities;
using System;

namespace SouJunior.Infra.Dtos
{
    public class EmpresaJrDto
    {
        public Guid Id { get; set; }
        public string ImagemPerfil { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string RamoAtuacao { get; set; }
        public EnderecoEntity Endereco { get; set; }
    }
}
