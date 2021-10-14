using SouJunior.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouJunior.Domain.Interfaces
{
    public interface IRamoAtuacaoRepository
    {
        Task<IList<RamoAtuacaoEntity>> GetAll();
    }
}
