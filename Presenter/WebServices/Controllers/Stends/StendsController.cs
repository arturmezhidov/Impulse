using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Stends;

namespace Impulse.Presenter.WebServices.Controllers.Stends
{
	public class StendsController : BaseApiController<Stend, StendViewModel>
	{
		protected IStendService BusinessService;

		public StendsController(IStendService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}