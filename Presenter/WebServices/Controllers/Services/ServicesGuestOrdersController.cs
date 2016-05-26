using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Services;

namespace Impulse.Presenter.WebServices.Controllers.Services
{
	public class ServicesGuestOrdersController : BaseDetailsApiController<ServiceGuestOrder, ServiceGuestOrderViewModel, ServiceGuestOrderDetailsModel>
	{
		protected IServiceGuestOrderService BusinessService;

		public ServicesGuestOrdersController(IServiceGuestOrderService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}