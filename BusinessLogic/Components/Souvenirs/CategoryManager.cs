using System.Linq;
using Impulse.BusinessLogic.BusinessContracts.Souvenirs;
using Impulse.Common.Models.Souvenirs;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Souvenirs
{
	public class CategoryManager : DataManager<Category>, ICategoryManager
	{
		protected IUnitOfWorkSouvenirs unitOfWork;

		public CategoryManager(IUnitOfWorkSouvenirs unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public override IQueryable<Category> GetAll()
		{
			return unitOfWork.Categories.GetAll().Where(i => !i.IsDeleted).OrderBy(i => i.SortingNumber);
		}

		protected override bool IsNewItem(Category item)
		{
			return item.Id <= 0;
		}
	}
}