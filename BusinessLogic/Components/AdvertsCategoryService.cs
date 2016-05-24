using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class AdvertsCategoryService : SorterService<AdvertsCategory>, IAdvertsCategoryService
	{
		public AdvertsCategoryService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}