using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class StendOrderService : DataService<StendOrder>, IStendOrderService
	{
		public StendOrderService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}