using System;

namespace SouJunior.Domain.Entities
{
    public abstract class BaseEntity
	{
		protected BaseEntity()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }
	}
}
