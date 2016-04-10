using Impulse.BusinessLogic.BusinessContracts.Services;
using Impulse.Common.Models.Services;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Services
{
	public class CategoryManager : DataManager<Category>, ICategoryManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public CategoryManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Category item)
		{
			return item.Id <= 0;
		}
	}
}