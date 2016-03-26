using System;
using Impulse.Common.Models.Advertisements;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork
	{
		IRepository<Advert> Adverts { get; }
		IRepository<AdvertsCategory> AdvertCategories { get; set; }
		IRepository<AdvertMaterial> AdvertMaterials { get; set; }
	}
}
