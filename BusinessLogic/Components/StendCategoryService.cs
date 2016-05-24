using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class StendCategoryService : SorterService<StendCategory>, IStendCategoryService
	{
		public StendCategoryService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}