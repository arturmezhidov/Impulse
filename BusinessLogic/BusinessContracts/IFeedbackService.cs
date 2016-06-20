using Impulse.Common.Models.Entities;

namespace Impulse.BusinessLogic.BusinessContracts
{
	public interface IFeedbackService : IDataService<Feedback>
	{
		Feedback Approve(int feedbackId);
	}
}
