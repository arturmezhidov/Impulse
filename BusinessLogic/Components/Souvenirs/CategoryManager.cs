using Impulse.BusinessLogic.BusinessContracts.Souvenirs;
using Impulse.Common.Models.Souvenirs;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Souvenirs
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