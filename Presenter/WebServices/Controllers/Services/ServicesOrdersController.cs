using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Services;

namespace Impulse.Presenter.WebServices.Controllers.Services
{
	public class ServicesOrdersController : BaseDetailsApiController<ServiceOrder, ServiceOrderViewModel, ServiceOrderDetailsModel>
	{
		protected IServiceOrderService BusinessService;

		public ServicesOrdersController(IServiceOrderService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}