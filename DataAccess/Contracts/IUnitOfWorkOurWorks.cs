using System;
using Impulse.Common.Models.OurWorks;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork
	{
		IRepository<WorkItem> WorkItems { get; }
		IRepository<WorkItemsCategory> WorkItemCategories { get; set; }
	}
}