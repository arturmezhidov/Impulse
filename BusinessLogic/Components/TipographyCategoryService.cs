using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class TipographyCategoryService : SorterService<TipographyCategory>, ITipographyCategoryService
	{
		public TipographyCategoryService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}