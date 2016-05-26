using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Application;

namespace Impulse.Presenter.WebServices.Controllers.Application
{
	public class EmailsController : BaseApiController<Email, EmailViewModel>
	{
		protected IEmailService BusinessService;

		public EmailsController(IEmailService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}