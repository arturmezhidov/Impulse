using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Souvenirs;

namespace Impulse.Presenter.WebServices.Controllers.Souvenirs
{
	public class SouvenirsGuestOrdersController : BaseDetailsApiController<SouvenirGuestOrder, SouvenirGuestOrderViewModel, SouvenirGuestOrderDetailsModel>
	{
		protected ISouvenirGuestOrderService BusinessSouvenir;

		public SouvenirsGuestOrdersController(ISouvenirGuestOrderService service)
			: base(service)
		{
			BusinessSouvenir = service;
		}
	}
}