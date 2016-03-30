using System;
using Impulse.Common.Models.Services;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWorkServices : IUnitOfWork
	{
		IRepository<Service> Services { get; }
		IRepository<Category> Categories { get; }
	}
}
