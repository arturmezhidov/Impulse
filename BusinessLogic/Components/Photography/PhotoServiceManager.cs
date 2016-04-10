using Impulse.BusinessLogic.BusinessContracts.Photography;
using Impulse.Common.Models.Photography;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Photography
{
	public class PhotoServiceManager : DataManager<PhotoService>, IPhotoServiceManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public PhotoServiceManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(PhotoService item)
		{
			return item.Id <= 0;
		}
	}
}