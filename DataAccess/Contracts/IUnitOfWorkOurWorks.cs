using System;
using Impulse.Common.Models.OurWorks;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork
	{
		IRepository<Item> WorkItems { get; }
		IRepository<Category> WorkItemCategories { get; }
	}
}