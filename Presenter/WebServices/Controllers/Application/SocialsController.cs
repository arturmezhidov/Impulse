using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Application;

namespace Impulse.Presenter.WebServices.Controllers.Application
{
	public class SocialsController : BaseApiController<Social, SocialViewModel>
	{
		protected ISocialService BusinessService;

		public SocialsController(ISocialService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}