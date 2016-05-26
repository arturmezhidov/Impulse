using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.OurWorks;
using Impulse.Common.Components;
using Impulse.Common.Models.OurWorks;
using Impulse.Presenter.WebServices.Filters;
using Impulse.Presenter.WebServices.Models.OurWorks;

namespace Impulse.Presenter.WebServices.Controllers.OurWorks
{
	[RoutePrefix("api/ourworks/items")]
	public class ItemsController : BaseApiController
	{
		protected IItemManager DataManager;

		public ItemsController(IItemManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(OurWorksItemViewModel vm)
		{
			Item newItem = Mapper.Mapp<OurWorksItemViewModel, Item>(vm);
			Item createdItem = DataManager.Create(newItem);

			var response = Mapper.Mapp<Item, OurWorksItemViewModel>(createdItem);

			return Created("api/ourworks/items/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var items = DataManager.GetAll();

			var response = Mapper.MappCollection<Item, OurWorksItemViewModel>(items);

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

			var response = Mapper.Mapp<Item, OurWorksItemViewModel>(item);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(OurWorksItemViewModel vm)
		{
			Item item = Mapper.Mapp<OurWorksItemViewModel, Item>(vm);
			Item updatedItem = DataManager.Update(item);

			var response = Mapper.Mapp<Item, OurWorksItemViewModel>(updatedItem);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			Item item = DataManager.Delete(id);

			if (item == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Item, OurWorksItemViewModel>(item);

			return Ok(response);
		}
	}
}
