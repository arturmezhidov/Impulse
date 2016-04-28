using Impulse.BusinessLogic.BusinessContracts.Stends;
using Impulse.Common.Models.Stends;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Stends
{
	public class CategoryManager : SorterManager<Category>, ICategoryManager
	{
		protected IUnitOfWorkStends unitOfWork;

		public CategoryManager(IUnitOfWorkStends unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}