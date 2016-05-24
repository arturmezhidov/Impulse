using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class SouvenirGuestOrderService : DataService<SouvenirGuestOrder>, ISouvenirGuestOrderService
	{
		public SouvenirGuestOrderService(IUnitOfWork uow)
			: base(uow)
		{
		}
	}
}