using System.Linq;
using Impulse.BusinessLogic.BusinessContracts.Stends;
using Impulse.Common.Models.Stends;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Stends
{
	public class StendManager : DataManager<Stend>, IStendManager
	{
		protected IUnitOfWorkStends unitOfWork;

		public StendManager(IUnitOfWorkStends unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public override IQueryable<Stend> GetAll()
		{
			return unitOfWork.Stends.GetAll().Where(i => !i.IsDeleted);
		}

		protected override bool IsNewItem(Stend item)
		{
			return item.Id <= 0;
		}
	}
}