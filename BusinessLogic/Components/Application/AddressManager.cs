using Impulse.BusinessLogic.BusinessContracts.Application;
using Impulse.Common.Models.Application;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Application
{
	public class AddressManager : DataManager<Address>, IAddressManager
	{
		protected IUnitOfWorkApplication unitOfWork;

		public AddressManager(IUnitOfWorkApplication unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}