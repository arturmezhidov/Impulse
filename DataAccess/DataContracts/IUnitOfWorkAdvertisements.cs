using Impulse.Common.Models.Advertisements;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWorkAdvertisements : IUnitOfWork
	{
		IRepository<Advert> Adverts { get; }
		IRepository<Type> Types { get; }
		IRepository<Material> Materials { get; }
	}
}
