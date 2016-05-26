using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Photography;

namespace Impulse.Presenter.WebServices.Controllers.Photography
{
	public class PhotoServicesController : BaseApiController<PhotoService, PhotoServiceViewModel>
	{
		protected IPhotoServicesService BusinessService;

		public PhotoServicesController(IPhotoServicesService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}
