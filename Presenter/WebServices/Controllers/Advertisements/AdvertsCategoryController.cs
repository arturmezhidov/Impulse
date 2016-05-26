using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Components;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Advertisements;

namespace Impulse.Presenter.WebServices.Controllers.Advertisements
{
	public class AdvertsCategoryController : BaseApiController<AdvertsCategory, AdvertCategoryViewModel>
	{
		protected IAdvertsCategoryService BusinessService;

		public AdvertsCategoryController(IAdvertsCategoryService service)
			: base(service)
		{
			BusinessService = service;
		}

		protected override AdvertCategoryViewModel ToViewModel(AdvertsCategory model)
		{
			var result = base.ToViewModel(model);
			var items = Mapper.MappCollection<Advert, AdvertViewModel>(model.Adverts);
			
			result.Adverts.AddRange(items);

			return result;
		}
	}
}