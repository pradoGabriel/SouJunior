using SouJunior.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouJunior.Infra.Interfaces
{
    public interface IRamoAtuacaoRepository
    {
        Task<IList<RamoAtuacaoEntity>> GetAll();
        Task<RamoAtuacaoEntity> GetById(int id);
    }
}
