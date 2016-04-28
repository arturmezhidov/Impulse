using Impulse.BusinessLogic.BusinessContracts.Application;
using Impulse.Common.Models.Application;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Application
{
	public class PhoneManager : DataManager<Phone>, IPhoneManager
	{
		protected IUnitOfWorkApplication unitOfWork;

		public PhoneManager(IUnitOfWorkApplication unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}