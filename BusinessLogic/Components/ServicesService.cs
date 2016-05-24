using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class ServicesService : SorterService<Service>, IServicesService
	{
		public ServicesService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}