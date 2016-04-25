using System.Linq;
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

		public override IQueryable<Advert> GetAll()
		{
			return unitOfWork.Adverts.GetAll().Where(i => !i.IsDeleted);
		}

		protected override bool IsNewItem(Advert item)
		{
			return item.Id <= 0;
		}
	}
}