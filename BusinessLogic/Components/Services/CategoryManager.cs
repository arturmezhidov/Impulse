using System.Linq;
using Impulse.BusinessLogic.BusinessContracts.Services;
using Impulse.Common.Models.Services;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Services
{
	public class CategoryManager : DataManager<Category>, ICategoryManager
	{
		protected IUnitOfWorkServices unitOfWork;

		public CategoryManager(IUnitOfWorkServices unitOfWork)
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