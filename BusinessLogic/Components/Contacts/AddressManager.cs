using Impulse.BusinessLogic.BusinessContracts.Contacts;
using Impulse.Common.Models.Contacts;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Contacts
{
	public class AddressManager : DataManager<Address>, IAddressManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public AddressManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Address item)
		{
			return item.Id <= 0;
		}
	}
}