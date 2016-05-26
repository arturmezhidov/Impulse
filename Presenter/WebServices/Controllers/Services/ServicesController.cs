using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Services;

namespace Impulse.Presenter.WebServices.Controllers.Services
{
	public class ServicesController : BaseApiController<Service, ServiceViewModel>
	{
		protected IServicesService BusinessService;

		public ServicesController(IServicesService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}