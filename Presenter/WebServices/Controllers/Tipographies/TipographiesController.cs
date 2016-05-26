using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Tipographies;

namespace Impulse.Presenter.WebServices.Controllers.Tipographies
{
	public class TipographiesController : BaseApiController<Tipography, TipographyViewModel>
	{
		protected ITipographyService BusinessService;

		public TipographiesController(ITipographyService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}