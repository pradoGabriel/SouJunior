using FluentValidation;
using SouJunior.Domain.Entities;
using System;
using System.Collections.Generic;


namespace SouJunior.Infra.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Delete(Guid id);

        IList<TEntity> Get();

        TEntity GetById(Guid id);

        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
