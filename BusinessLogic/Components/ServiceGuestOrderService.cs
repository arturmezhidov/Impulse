using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class ServiceGuestOrderService : DataService<ServiceGuestOrder>, IServiceGuestOrderService
	{
		public ServiceGuestOrderService(IUnitOfWork uow)
			: base(uow)
		{
		}
	}
}