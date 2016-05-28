using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class FeedbackService : DataService<Feedback>, IFeedbackService
	{
		public FeedbackService(IUnitOfWork uow)
			: base(uow)
		{
		}
	}
}