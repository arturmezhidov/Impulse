using Impulse.BusinessLogic.BusinessContracts.Application;
using Impulse.Common.Models.Application;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Application
{
	public class UsersManager : DataManager<ProfileUser>, IUserManager
	{
		private IUnitOfWorkApplication uow;

		public UsersManager(IUnitOfWorkApplication uow) : base(uow)
		{
			this.uow = uow;
		}
	}
}
