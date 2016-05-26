using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class OurWorksItemService : DataService<OurWorksItem>, IOurWorksItemService
	{
		public OurWorksItemService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}