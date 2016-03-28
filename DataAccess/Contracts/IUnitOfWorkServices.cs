using System;
using Impulse.Common.Models.Services;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork
	{
		IRepository<Service> Services { get; }
		IRepository<ServicesCategory> ServicesCategories { get; }
	}
}
