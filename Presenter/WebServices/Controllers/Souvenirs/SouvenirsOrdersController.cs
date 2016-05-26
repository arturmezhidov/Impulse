using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Souvenirs;

namespace Impulse.Presenter.WebServices.Controllers.Souvenirs
{
	public class SouvenirsOrdersController : BaseDetailsApiController<SouvenirOrder, SouvenirOrderViewModel, SouvenirOrderDetailsModel>
	{
		protected ISouvenirOrderService BusinessService;

		public SouvenirsOrdersController(ISouvenirOrderService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}