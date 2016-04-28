using Impulse.BusinessLogic.BusinessContracts.Stends;
using Impulse.Common.Models.Stends;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Stends
{
	public class MaterialManager : DataManager<Material>, IMaterialManager
	{
		protected IUnitOfWorkStends unitOfWork;

		public MaterialManager(IUnitOfWorkStends unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}