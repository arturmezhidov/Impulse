using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Application;

namespace Impulse.Presenter.WebServices.Controllers.Application
{
	public class FeedbackController : BaseApiController<Feedback, FeedbackViewModel>
	{
		protected IFeedbackService BusinessService;

		public FeedbackController(IFeedbackService service)
			: base(service)
		{
			BusinessService = service;
		}

		[HttpPut]
		public override IHttpActionResult Update(FeedbackViewModel vm)
		{
			if (vm == null)
			{
				return BadRequest(ModelState);
			}

			var result = BusinessService.Approve(vm.Id);

			if (result == null)
			{
				return BadRequest(ModelState);
			}

			return Ok(result);
		}
	}
}