using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Application;

namespace Impulse.Presenter.WebServices.Controllers.Application
{
	public class PhonesController : BaseApiController<Phone, PhoneViewModel>
	{
		protected IPhoneService BusinessService;

		public PhonesController(IPhoneService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}