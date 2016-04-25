using Impulse.BusinessLogic.BusinessContracts.Contacts;
using Impulse.Common.Models.Contacts;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Contacts
{
	public class EmailManager : DataManager<Email>, IEmailManager
	{
		protected IUnitOfWorkContacts unitOfWork;

		public EmailManager(IUnitOfWorkContacts unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Email item)
		{
			return item.Id <= 0;
		}
	}
}