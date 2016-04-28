using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using Impulse.Common.Models.Advertisements;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Advertisements
{
	public class AdvertManager : DataManager<Advert>, IAdvertManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public AdvertManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}