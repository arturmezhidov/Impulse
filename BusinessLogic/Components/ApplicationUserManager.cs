using System;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;
using Microsoft.AspNet.Identity;

namespace Impulse.BusinessLogic.Components
{
	public class ApplicationUserManager : UserManager<ApplicationUser>, IUserManager
	{
		protected readonly IUnitOfWork UnitOfWork;

		public ApplicationUserManager(IUnitOfWork uow)
			: base(uow.ApplicationUsers)
		{
			UnitOfWork = uow;
		}
	}
}
