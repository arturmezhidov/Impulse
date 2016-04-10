using Impulse.BusinessLogic.BusinessContracts.Stends;
using Impulse.Common.Models.Stends;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Stends
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