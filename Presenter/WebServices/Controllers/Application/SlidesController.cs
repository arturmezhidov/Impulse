using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Application;

namespace Impulse.Presenter.WebServices.Controllers.Application
{
	public class SlidesController : BaseApiController<Slide, SlideViewModel>
	{
		protected ISlideService BusinessService;

		public SlidesController(ISlideService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}