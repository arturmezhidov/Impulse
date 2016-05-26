using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Components;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Stends;

namespace Impulse.Presenter.WebServices.Controllers.Stends
{
	public class StendsCategoriesController : BaseApiController<StendCategory, StendCategoryViewModel>
	{
		protected IStendCategoryService BusinessService;

		public StendsCategoriesController(IStendCategoryService service)
			: base(service)
		{
			BusinessService = service;
		}

		protected override StendCategoryViewModel ToViewModel(StendCategory model)
		{
			var result = base.ToViewModel(model);
			var items = Mapper.MappCollection<Stend, StendViewModel>(model.Stends);

			result.Stends.AddRange(items);

			return result;
		}
	}
}
