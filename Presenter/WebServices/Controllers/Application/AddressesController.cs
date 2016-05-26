using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Application;

namespace Impulse.Presenter.WebServices.Controllers.Application
{
	public class AddressesController : BaseApiController<Address, AddressViewModel>
	{
		protected IAddressService BusinessService;

		public AddressesController(IAddressService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}