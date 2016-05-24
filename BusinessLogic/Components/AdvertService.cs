using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class AdvertService : DataService<Advert>, IAdvertService
	{
		public AdvertService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}