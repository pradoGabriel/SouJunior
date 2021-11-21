using System;

namespace SouJunior.Domain.Filters
{
    public class PropostaFilter
    {
        public Guid? EmpreendedorId { get; set; }
        public Guid? EmpresaJrId { get; set; }
        public bool? IsAceita { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
