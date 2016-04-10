using Impulse.BusinessLogic.BusinessContracts.Tipographies;
using Impulse.Common.Models.Tipographies;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Tipographies
{
	public class KindManager : DataManager<Kind>, IKindManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public KindManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Kind item)
		{
			return item.Id <= 0;
		}
	}
}