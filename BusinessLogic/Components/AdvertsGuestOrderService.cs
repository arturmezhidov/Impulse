using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class AdvertsGuestOrderService : DataService<AdvertsGuestOrder>, IAdvertsGuestOrderService
	{
		public AdvertsGuestOrderService(IUnitOfWork uow)
			: base(uow)
		{
		}
	}
}