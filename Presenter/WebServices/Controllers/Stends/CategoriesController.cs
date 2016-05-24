using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Stends;
using Impulse.Common.Components;
using Impulse.Common.Models;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Filters;
using Impulse.Presenter.WebServices.Models.Stends;

namespace Impulse.Presenter.WebServices.Controllers.Stends
{
	[RoutePrefix("api/stends/categories")]
	public class CategoriesController : BaseApiController
	{
		protected ICategoryManager DataManager;

		public CategoriesController(ICategoryManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(CategoryViewModel vm)
		{
			StendCategory newCategory = Mapper.Mapp<CategoryViewModel, StendCategory>(vm);
			StendCategory createdCategory = DataManager.Create(newCategory);

			var response = Mapper.Mapp<StendCategory, CategoryViewModel>(createdCategory);

			return Created("api/stends/categories/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var categories = DataManager.GetAll();

			var response = Mapper.MappCollection<StendCategory, CategoryViewModel>(categories);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult GetById(int id)
		{
			var category = DataManager.GetById(id);

			if (category == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<StendCategory, CategoryViewModel>(category);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}/stends")]
		public IHttpActionResult GetServicesByCategory(int id)
		{
			var category = DataManager.GetById(id);

			if (category == null)
			{
				return NotFound();
			}

			var response = Mapper.MappCollection<Stend, StendViewModel>(category.Stends);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(CategoryViewModel vm)
		{
			StendCategory category = Mapper.Mapp<CategoryViewModel, StendCategory>(vm);
			StendCategory updatedCategory = DataManager.Update(category);

			var response = Mapper.Mapp<StendCategory, CategoryViewModel>(updatedCategory);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			StendCategory category = DataManager.Delete(id);

			if (category == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<StendCategory, CategoryViewModel>(category);

			return Ok(response);
		}
	}
}
