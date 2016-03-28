using System;
using Impulse.Common.Models.Stends;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork
	{
		IRepository<Stend> Stends { get; }
		IRepository<Category> StendsCategories { get; }
		IRepository<Material> StendsMaterials { get; }
	}
}