using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.OurWorks;

namespace Impulse.Presenter.WebServices.Controllers.OurWorks
{
	public class OurWorksItemsController : BaseApiController<OurWorksItem, OurWorksItemViewModel>
	{
		protected IOurWorksItemService BusinessService;

		public OurWorksItemsController(IOurWorksItemService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}