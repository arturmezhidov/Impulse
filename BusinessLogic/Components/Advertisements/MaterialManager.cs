using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using Impulse.Common.Models.Advertisements;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Advertisements
{
	public class MaterialManager : DataManager<Material>, IMaterialManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public MaterialManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Material item)
		{
			return item.Id <= 0;
		}
	}
}