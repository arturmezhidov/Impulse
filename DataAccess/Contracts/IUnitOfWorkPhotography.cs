using System;
using Impulse.Common.Models.Photography;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork
	{
		IRepository<PhotoService> PhotoServices { get; }
	}
}