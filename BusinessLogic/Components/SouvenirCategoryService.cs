using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class SouvenirCategoryService : SorterService<SouvenirCategory>, ISouvenirCategoryService
	{
		public SouvenirCategoryService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}