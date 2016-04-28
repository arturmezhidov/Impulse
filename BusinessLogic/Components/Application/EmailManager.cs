using Impulse.BusinessLogic.BusinessContracts.Application;
using Impulse.Common.Models.Application;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Application
{
	public class EmailManager : DataManager<Email>, IEmailManager
	{
		protected IUnitOfWorkApplication unitOfWork;

		public EmailManager(IUnitOfWorkApplication unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}