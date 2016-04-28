using Impulse.BusinessLogic.BusinessContracts.Services;
using Impulse.Common.Models.Services;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Services
{
	public class CategoryManager : SorterManager<Category>, ICategoryManager
	{
		protected IUnitOfWorkServices unitOfWork;

		public CategoryManager(IUnitOfWorkServices unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}