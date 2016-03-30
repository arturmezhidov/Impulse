using System;
using Impulse.Common.Models.Stends;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWorkStends : IUnitOfWork
	{
		IRepository<Stend> Stends { get; }
		IRepository<Category> Categories { get; }
		IRepository<Material> Materials { get; }
	}
}