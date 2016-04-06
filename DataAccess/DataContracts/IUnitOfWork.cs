using System;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<T> GetRepository<T>() where T : class, new();
		void Save();
	}
}