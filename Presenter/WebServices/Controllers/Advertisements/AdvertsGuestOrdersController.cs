using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Advertisements;

namespace Impulse.Presenter.WebServices.Controllers.Advertisements
{
	public class AdvertsGuestOrdersController : BaseDetailsApiController<AdvertsGuestOrder, AdvertsGuestOrderViewModel, AdvertsGuestOrderDetailsModel>
	{
		protected IAdvertsGuestOrderService BusinessService;

		public AdvertsGuestOrdersController(IAdvertsGuestOrderService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}