using System;
using Impulse.Common.Models.Photography;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWorkPhotography : IUnitOfWork
	{
		IRepository<PhotoService> PhotoServices { get; }
	}
}