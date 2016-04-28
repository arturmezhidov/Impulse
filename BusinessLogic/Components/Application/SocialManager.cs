using Impulse.BusinessLogic.BusinessContracts.Application;
using Impulse.Common.Models.Application;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Application
{
	public class SocialManager : DataManager<Social>, ISocialManager
	{
		protected IUnitOfWorkApplication unitOfWork;

		public SocialManager(IUnitOfWorkApplication unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}