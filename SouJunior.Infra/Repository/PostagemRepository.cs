using SouJunior.Domain.Entities;
using SouJunior.Infra.Data.Context;
using SouJunior.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouJunior.Infra.Repository
{
    public class PostagemRepository : IPostagemRepository
    {
        protected readonly MyContext _context;

        public PostagemRepository(MyContext myContext)
        {
            _context = myContext;
        }

        public List<PostagemEntity> FilterByProposta(Guid propostaId)
        {
            return _context.Postagem.Where(_ => _.PropostaId == propostaId).OrderByDescending(x => x.DataHora).ToList();
        }
    }
}
