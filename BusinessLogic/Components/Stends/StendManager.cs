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
	}
}