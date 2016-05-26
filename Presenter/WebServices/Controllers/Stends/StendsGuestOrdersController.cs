using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Stends;

namespace Impulse.Presenter.WebServices.Controllers.Stends
{
	public class StendsGuestOrdersController : BaseDetailsApiController<StendGuestOrder, StendGuestOrderViewModel, StendGuestOrderDetailsModel>
	{
		protected IStendGuestOrderService BusinessStend;

		public StendsGuestOrdersController(IStendGuestOrderService service)
			: base(service)
		{
			BusinessStend = service;
		}
	}
}