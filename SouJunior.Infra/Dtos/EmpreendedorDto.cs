using SouJunior.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SouJunior.Infra.Dtos
{
    public class EmpreendedorDto
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
