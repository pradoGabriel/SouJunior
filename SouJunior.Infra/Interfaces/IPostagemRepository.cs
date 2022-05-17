using SouJunior.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SouJunior.Infra.Interfaces
{
    public interface IPostagemRepository
    {
        List<PostagemEntity> FilterByProposta(Guid propostaId);
    }
}
