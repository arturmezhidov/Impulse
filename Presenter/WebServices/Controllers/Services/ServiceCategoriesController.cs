using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Components;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Services;

namespace Impulse.Presenter.WebServices.Controllers.Services
{
	public class ServiceCategoriesController : BaseApiController<ServiceCategory, ServiceCategoryViewModel>
	{
		protected IServiceCategoryService BusinessService;

		public ServiceCategoriesController(IServiceCategoryService service)
			: base(service)
		{
			BusinessService = service;
		}

		protected override ServiceCategoryViewModel ToViewModel(ServiceCategory model)
		{
			var result = base.ToViewModel(model);
			var items = Mapper.MappCollection<Service, ServiceViewModel>(model.Services);

			result.Services.AddRange(items);

			return result;
		}
	}
}
