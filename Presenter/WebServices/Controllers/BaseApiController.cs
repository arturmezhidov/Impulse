using System.Linq;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Components;
using Impulse.Presenter.WebServices.Filters;

namespace Impulse.Presenter.WebServices.Controllers
{
	public abstract class BaseApiController<TModel, TViewModel> : ApiController
		where TModel : class, new()
		where TViewModel : class, new()
	{
		protected readonly IDataService<TModel> DataService;

		protected BaseApiController(IDataService<TModel> dataService)
		{
			DataService = dataService;
		}

		[HttpGet]
		public virtual IHttpActionResult GetAll()
		{
			var response = DataService
				.GetAll()
				.Select(ToViewModel);

			return Ok(response);
		}

		[HttpGet]
		public virtual IHttpActionResult GetById(int id)
		{
			var response = ToViewModel(DataService.GetById(id));

			return Ok(response);
		}

		[HttpPost]
		[ModelCheck]
		public virtual IHttpActionResult Create(TViewModel vm)
		{
			var model = ToModel(vm);
			var result = DataService.Create(model);
			var response = ToViewModel(result);

			return Ok(response);
		}

		[HttpPut]
		[ModelCheck]
		public virtual IHttpActionResult Update(TViewModel vm)
		{
			var model = ToModel(vm);
			var result = DataService.Update(model);
			var response = ToViewModel(result);

			return Ok(response);
		}

		[HttpDelete]
		public virtual IHttpActionResult Delete(int id)
		{
			var result = DataService.Delete(id);

			if (result == null)
			{
				return NotFound();
			}

			var response = ToViewModel(result);

			return Ok(response);
		}

		protected virtual TViewModel ToViewModel(TModel model)
		{
			var result = Mapper.Mapp<TViewModel>(model);
			return result;
		}

		protected virtual TModel ToModel(TViewModel viewModel)
		{
			var result = Mapper.Mapp<TModel>(viewModel);
			return result;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				DataService.Dispose();
			}
		}
	}
}