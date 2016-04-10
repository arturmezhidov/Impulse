using Impulse.BusinessLogic.BusinessContracts.Souvenirs;
using Impulse.Common.Models.Souvenirs;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Souvenirs
{
	public class SouvenirManager : DataManager<Souvenir>, ISouvenirManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public SouvenirManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Souvenir item)
		{
			return item.Id <= 0;
		}
	}
}