﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SouJunior.Domain.Entities
{
    public class PropostaEntity : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid EmpresaJrId { get; set; }
        public Guid EmpreendedorId { get; set; }
    }
}