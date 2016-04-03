using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		protected readonly DbContext Context;
		private bool disposed;

		public UnitOfWork(DbContext instance)
		{
			Context = instance;
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