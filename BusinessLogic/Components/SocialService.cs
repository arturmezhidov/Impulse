using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class SocialService : DataService<Social>, ISocialService
	{
		public SocialService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}