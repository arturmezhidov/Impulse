using System;
using System.Data.Entity;
using Impulse.DataAccess.DataContracts;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public abstract class UnitOfWork : IUnitOfWork
	{
		protected readonly DbContext Context;
		private bool disposed;

		public UnitOfWork(DbContext instance)
		{
			Context = instance;
		}

		public abstract IRepository<T> GetRepository<T>() where T : class, new();

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