using System.Linq;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Components;
using Impulse.Presenter.WebServices.Filters;

namespace Impulse.Presenter.WebServices.Controllers
{
	public abstract class BaseDetailsApiController<TModel, TViewModel, TDetailsModel> : BaseApiController<TModel, TViewModel>
		where TModel : class, new()
		where TViewModel : class, new()
		where TDetailsModel : class, new()
	{

		protected BaseDetailsApiController(IDataService<TModel> dataService)
			: base(dataService) { }

		[HttpGet]
		public override IHttpActionResult GetAll()
		{
			var response = DataService
				.GetAll()
				.Select(ToDetailsModel);

			return Ok(response);
		}

		[HttpGet]
		public override IHttpActionResult GetById(int id)
		{
			var response = ToDetailsModel(DataService.GetById(id));

			return Ok(response);
		}

		[HttpPost]
		[ModelCheck]
		public override IHttpActionResult Create(TViewModel vm)
		{
			var model = ToModel(vm);
			var result = DataService.Create(model);
			var response = ToViewModel(result);

			return Ok(response);
		}

		[HttpPut]
		[ModelCheck]
		public override IHttpActionResult Update(TViewModel vm)
		{
			var model = ToModel(vm);
			var result = DataService.Update(model);
			var response = ToDetailsModel(result);

			return Ok(response);
		}

		protected virtual TModel ToModel(TDetailsModel details)
		{
			var result = Mapper.Mapp<TModel>(details);
			return result;
		}
		protected virtual TDetailsModel ToDetailsModel(TModel model)
		{
			var result = Mapper.Mapp<TDetailsModel>(model);
			return result;
		}
	}
}