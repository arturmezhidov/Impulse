using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class StendGuestOrderService : DataService<StendGuestOrder>, IStendGuestOrderService
	{
		public StendGuestOrderService(IUnitOfWork uow)
			: base(uow)
		{
		}
	}
}