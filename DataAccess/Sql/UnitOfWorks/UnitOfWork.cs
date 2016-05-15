using System;
using System.Data.Entity;
using System.Linq;
using Impulse.DataAccess.DataContracts;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public abstract class UnitOfWork : IUnitOfWork
	{
		protected readonly DbContext Context;
		private bool disposed;

		protected UnitOfWork(DbContext instance)
		{
			Context = instance;
		}

		public virtual IRepository<T> GetRepository<T>() where T : class, new()
		{
			var property = GetType().GetProperties().FirstOrDefault(i => i.PropertyType == typeof (IRepository<T>));

			return (IRepository<T>)property.GetValue(this);
		}

		public void Save()
		{
			Context.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Context.Dispose();
				}
				disposed = true;
			}
		}
	}
}