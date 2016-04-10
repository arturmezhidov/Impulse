using Impulse.BusinessLogic.BusinessContracts.Contacts;
using Impulse.Common.Models.Contacts;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Contacts
{
	public class SocialManager : DataManager<Social>, ISocialManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public SocialManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Social item)
		{
			return item.Id <= 0;
		}
	}
}