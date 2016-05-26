using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Components;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Souvenirs;

namespace Impulse.Presenter.WebServices.Controllers.Souvenirs
{
	public class SouvenirsCategoriesController : BaseApiController<SouvenirCategory, SouvenirCategoryViewModel>
	{
		protected ISouvenirCategoryService BusinessService;

		public SouvenirsCategoriesController(ISouvenirCategoryService service)
			: base(service)
		{
			BusinessService = service;
		}

		protected override SouvenirCategoryViewModel ToViewModel(SouvenirCategory model)
		{
			var result = base.ToViewModel(model);
			var items = Mapper.MappCollection<Souvenir, SouvenirViewModel>(model.Souvenirs);

			result.Souvenirs.AddRange(items);

			return result;
		}
	}
}
