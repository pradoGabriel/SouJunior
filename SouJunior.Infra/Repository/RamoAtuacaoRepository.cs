using Microsoft.EntityFrameworkCore;
using SouJunior.Domain.Entities;
using SouJunior.Domain.Interfaces;
using SouJunior.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouJunior.Infra.Repository
{
    public class RamoAtuacaoRepository : IRamoAtuacaoRepository
    {
        protected readonly MyContext _context;

        public RamoAtuacaoRepository(MyContext myContext)
        {
            _context = myContext;
        }

        public async Task<IList<RamoAtuacaoEntity>> GetAll()
        {
            return await _context.RamoAtuacao.ToListAsync();
        }
    }
}
