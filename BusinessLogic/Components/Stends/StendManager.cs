using Impulse.BusinessLogic.BusinessContracts.Stends;
using Impulse.Common.Models.Stends;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Stends
{
	public class StendManager : DataManager<Stend>, IStendManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public StendManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Stend item)
		{
			return item.Id <= 0;
		}
	}
}