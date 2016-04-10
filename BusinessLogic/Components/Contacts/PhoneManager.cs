using Impulse.BusinessLogic.BusinessContracts.Contacts;
using Impulse.Common.Models.Contacts;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Contacts
{
	public class PhoneManager : DataManager<Phone>, IPhoneManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public PhoneManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Phone item)
		{
			return item.Id <= 0;
		}
	}
}