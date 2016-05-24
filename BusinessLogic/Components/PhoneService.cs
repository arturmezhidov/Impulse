using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class PhoneService : DataService<Phone>, IPhoneService
	{
		public PhoneService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}