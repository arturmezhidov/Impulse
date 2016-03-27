using System;
using Impulse.Common.Models.Advertisements;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork
	{
		IRepository<Advert> Adverts { get; }
		IRepository<Category> AdvertCategories { get; }
		IRepository<Material> AdvertMaterials { get; }
	}
}
