using SouJunior.Domain.Entities;
using SouJunior.Infra.Data.Context;
using SouJunior.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SouJunior.Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		protected readonly MyContext _myContext;

		public BaseRepository(MyContext myContext)
		{
			_myContext = myContext;
		}

		public void Insert(TEntity obj)
		{
			_myContext.Set<TEntity>().Add(obj);
			_myContext.SaveChanges();
		}

		public void Update(TEntity obj)
		{
			_myContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_myContext.SaveChanges();
		}

		public void Delete(Guid id)
		{
			_myContext.Set<TEntity>().Remove(Select(id));
			_myContext.SaveChanges();
		}

		public IList<TEntity> Select() =>
			_myContext.Set<TEntity>().ToList();

		public TEntity Select(Guid id) =>
			_myContext.Set<TEntity>().Find(id);
	}
}
