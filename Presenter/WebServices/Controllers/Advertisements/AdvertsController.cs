using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Advertisements;

namespace Impulse.Presenter.WebServices.Controllers.Advertisements
{
	public class AdvertsController : BaseApiController<Advert, AdvertViewModel>
	{
		protected IAdvertService BusinessService;

		public AdvertsController(IAdvertService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}