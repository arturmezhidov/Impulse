using System;
using Impulse.Common.Models.Tipographies;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork
	{
		IRepository<Tipography> Tipographies { get; set; }
		IRepository<TipographiesCategory> TipographiesCategories { get; set; }
	}
}
