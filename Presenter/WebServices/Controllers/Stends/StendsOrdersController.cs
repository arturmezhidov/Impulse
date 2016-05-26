using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Stends;

namespace Impulse.Presenter.WebServices.Controllers.Stends
{
	public class StendsOrdersController : BaseDetailsApiController<StendOrder, StendOrderViewModel, StendOrderDetailsModel>
	{
		protected IStendOrderService BusinessService;

		public StendsOrdersController(IStendOrderService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}