using Impulse.BusinessLogic.BusinessContracts.Services;
using Impulse.Common.Models.Services;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Services
{
	public class ServiceManager : DataManager<Service>, IServiceManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public ServiceManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Service item)
		{
			return item.Id <= 0;
		}
	}
}