using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class ServiceOrderService : DataService<ServiceOrder>, IServiceOrderService
	{
		public ServiceOrderService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}