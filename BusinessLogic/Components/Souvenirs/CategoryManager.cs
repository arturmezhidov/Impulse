using Impulse.BusinessLogic.BusinessContracts.Souvenirs;
using Impulse.Common.Models.Souvenirs;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Souvenirs
{
	public class CategoryManager : SorterManager<Category>, ICategoryManager
	{
		protected IUnitOfWorkSouvenirs unitOfWork;

		public CategoryManager(IUnitOfWorkSouvenirs unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}