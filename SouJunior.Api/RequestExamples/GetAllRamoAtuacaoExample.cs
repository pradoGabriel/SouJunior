using SouJunior.Domain.Entities;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace SouJunior.Api.RequestExamples
{
    public class GetAllRamoAtuacaoExample : IExamplesProvider<List<RamoAtuacaoEntity>>
    {
        public List<RamoAtuacaoEntity> GetExamples()
        {
            var list = new List<RamoAtuacaoEntity>();

            list.Add(new RamoAtuacaoEntity()
            {
                Id = 1,
                Descricao = "Comércio"
            });
            list.Add(new RamoAtuacaoEntity()
            {
                Id = 2,
                Descricao = "Industria"
            });
            list.Add(new RamoAtuacaoEntity()
            {
                Id = 3,
                Descricao = "Outros"
            });

            return list;
        }
    }
}
