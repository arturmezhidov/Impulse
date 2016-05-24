using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class AdvertsOrderService : DataService<AdvertsOrder>, IAdvertsOrderService
	{
		public AdvertsOrderService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}