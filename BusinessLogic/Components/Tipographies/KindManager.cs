using Impulse.BusinessLogic.BusinessContracts.Tipographies;
using Impulse.Common.Models.Tipographies;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Tipographies
{
	public class KindManager : SorterManager<Kind>, IKindManager
	{
		protected IUnitOfWorkTipographies unitOfWork;

		public KindManager(IUnitOfWorkTipographies unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}