﻿using System;

namespace SouJunior.Domain.Entities
{
    public class EmpresaJrEntity : BaseEntity 
    {
        public string Cnpj { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public RamoAtuacaoEntity RamoAtuacao { get; set; }
    }
}
