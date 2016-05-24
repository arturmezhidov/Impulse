using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class StendService : DataService<Stend>, IStendService
	{
		public StendService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}