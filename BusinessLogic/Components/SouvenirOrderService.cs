using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class SouvenirOrderService : DataService<SouvenirOrder>, ISouvenirOrderService
	{
		public SouvenirOrderService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}