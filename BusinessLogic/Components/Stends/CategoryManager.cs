using Impulse.BusinessLogic.BusinessContracts.Stends;
using Impulse.Common.Models.Stends;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Stends
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