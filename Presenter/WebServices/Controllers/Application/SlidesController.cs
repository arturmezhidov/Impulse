using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Application;
using Impulse.Common.Components;
using Impulse.Common.Models.Application;
using Impulse.Presenter.WebServices.Filters;
using Impulse.Presenter.WebServices.Models.Application;

namespace Impulse.Presenter.WebServices.Controllers.Application
{
	[RoutePrefix("api/slides")]
	public class SlidesController : BaseApiController
	{
		protected ISlideManager DataManager;

		public SlidesController(ISlideManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(SlideViewModel vm)
		{
			Slide newItem = Mapper.Mapp<SlideViewModel, Slide>(vm);
			Slide createdItem = DataManager.Create(newItem);

			var response = Mapper.Mapp<Slide, SlideViewModel>(createdItem);

			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var items = DataManager.GetAll();

			var response = Mapper.MappCollection<Slide, SlideViewModel>(items);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult GetById(int id)
		{
			var item = DataManager.GetById(id);

			if (item == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Slide, SlideViewModel>(item);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(SlideViewModel vm)
		{
			Slide item = Mapper.Mapp<SlideViewModel, Slide>(vm);
			Slide updatedItem = DataManager.Update(item);

			var response = Mapper.Mapp<Slide, SlideViewModel>(updatedItem);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			var item = DataManager.Delete(id);

			if (item == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Slide, SlideViewModel>(item);

			return Ok(response);
		}
	}
}