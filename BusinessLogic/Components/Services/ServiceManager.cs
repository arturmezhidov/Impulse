using Impulse.BusinessLogic.BusinessContracts.Services;
using Impulse.Common.Models.Services;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Services
{
	public class ServiceManager : SorterManager<Service>, IServiceManager
	{
		protected IUnitOfWorkServices unitOfWork;

		public ServiceManager(IUnitOfWorkServices unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}