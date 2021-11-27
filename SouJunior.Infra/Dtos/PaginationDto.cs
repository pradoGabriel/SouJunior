using System.Collections.Generic;

namespace SouJunior.Infra.Dtos
{
    public class PaginationDto<T> : List<T>
    {
        public List<T> Dados { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public int TotalItems { get; set; }
    }
}
