using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class EmailService : DataService<Email>, IEmailService
	{
		public EmailService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}