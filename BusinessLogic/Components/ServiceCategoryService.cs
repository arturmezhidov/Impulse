using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class ServiceCategoryService : SorterService<ServiceCategory>, IServiceCategoryService
	{
		public ServiceCategoryService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}