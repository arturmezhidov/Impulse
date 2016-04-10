using Impulse.BusinessLogic.BusinessContracts.Tipographies;
using Impulse.Common.Models.Tipographies;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Tipographies
{
	public class TipographyManager : DataManager<Tipography>, ITipographyManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public TipographyManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Tipography item)
		{
			return item.Id <= 0;
		}
	}
}