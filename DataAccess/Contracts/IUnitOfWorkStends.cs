using System;
using Impulse.Common.Models.Stends;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork
	{
		IRepository<Stend> Stends { get; }
		IRepository<StendsCategory> StendsCategories { get; set; }
		IRepository<StendsMaterial> StendsMaterials { get; set; }
	}
}