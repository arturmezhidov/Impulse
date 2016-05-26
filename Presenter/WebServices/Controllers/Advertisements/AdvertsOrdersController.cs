using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Advertisements;

namespace Impulse.Presenter.WebServices.Controllers.Advertisements
{
	public class AdvertsOrdersController : BaseDetailsApiController<AdvertsOrder, AdvertsOrderViewModel, AdvertsOrderDetailsModel>
	{
		protected IAdvertsOrderService BusinessService;

		public AdvertsOrdersController(IAdvertsOrderService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}