using System.Linq;
using Impulse.BusinessLogic.BusinessContracts.Tipographies;
using Impulse.Common.Models.Tipographies;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Tipographies
{
	public class KindManager : DataManager<Kind>, IKindManager
	{
		protected IUnitOfWorkTipographies unitOfWork;

		public KindManager(IUnitOfWorkTipographies unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public override IQueryable<Kind> GetAll()
		{
			return unitOfWork.Kinds.GetAll().Where(i => !i.IsDeleted).OrderBy(i => i.SortingNumber);
		}

		protected override bool IsNewItem(Kind item)
		{
			return item.Id <= 0;
		}
	}
}