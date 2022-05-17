using SouJunior.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SouJunior.Infra.Dtos
{
    public class PropostaDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool? IsAceita { get; set; }
        public EmpreendedorDto? Empreendedor { get; set; }
        public EmpresaJrDto? EmpresaJr { get; set; }
        public EstudanteDto? Estudante { get; set; }
        public List<PostagemEntity>? Postagens { get; set; }
    }
}
