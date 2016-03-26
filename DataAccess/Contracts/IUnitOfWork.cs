using System;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork : IDisposable
	{
		void Save();
	}
}