using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Components;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Tipographies;

namespace Impulse.Presenter.WebServices.Controllers.Tipographies
{
	public class TipographiesCategoriesController : BaseApiController<TipographyCategory, TipographyCategoryViewModel>
	{
		protected ITipographyCategoryService BusinessService;

		public TipographiesCategoriesController(ITipographyCategoryService service)
			: base(service)
		{
			BusinessService = service;
		}

		protected override TipographyCategoryViewModel ToViewModel(TipographyCategory model)
		{
			var result = base.ToViewModel(model);
			var items = Mapper.MappCollection<Tipography, TipographyViewModel>(model.Tipographies);

			result.Tipographies.AddRange(items);

			return result;
		}
	}
}