using SouJunior.Domain.Entities;
using SouJunior.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SouJunior.Infra.Dtos
{
    public class EstudanteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Instituicao { get; set; }
        public string Curso { get; set; }
        public string Telefone { get; set; }
        public string ImagemPerfil { get; set; }
        public PeriodoEnum Periodo { get; set; }
        public EnderecoEntity Endereco { get; set; }
    }
}
