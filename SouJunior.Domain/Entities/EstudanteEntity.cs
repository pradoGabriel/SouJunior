using SouJunior.Domain.Enums;

namespace SouJunior.Domain.Entities
{
    public class EstudanteEntity : BaseEntity
    {
        public string Cpf { get; set; }
        public string Instituicao { get; set; }
        public string Curso { get; set; }
        public PeriodoEnum Periodo { get; set; }
    }
}
