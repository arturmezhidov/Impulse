using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class SlideService : DataService<Slide>, ISlideService
	{
		public SlideService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}