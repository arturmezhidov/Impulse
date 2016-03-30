using System;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWork : IDisposable
	{
		void Save();
	}
}