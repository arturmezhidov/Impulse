using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Souvenirs;
using Impulse.Common.Components;
using Impulse.Common.Models;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Filters;
using Impulse.Presenter.WebServices.Models.Souvenirs;

namespace Impulse.Presenter.WebServices.Controllers.Souvenirs
{
	[RoutePrefix("api/souvenirs/categories")]
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
		public IHttpActionResult Create(SouvenirCategoryViewModel vm)
		{
			SouvenirCategory newCategory = Mapper.Mapp<SouvenirCategoryViewModel, SouvenirCategory>(vm);
			SouvenirCategory createdCategory = DataManager.Create(newCategory);

			var response = Mapper.Mapp<SouvenirCategory, SouvenirCategoryViewModel>(createdCategory);

			return Created("api/souvenirs/categories/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var categories = DataManager.GetAll();

			var response = Mapper.MappCollection<SouvenirCategory, SouvenirCategoryViewModel>(categories);

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

			var response = Mapper.Mapp<SouvenirCategory, SouvenirCategoryViewModel>(category);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}/souvenirs")]
		public IHttpActionResult GetServicesByCategory(int id)
		{
			var category = DataManager.GetById(id);

			if (category == null)
			{
				return NotFound();
			}

			var response = Mapper.MappCollection<Souvenir, SouvenirViewModel>(category.Souvenirs);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(SouvenirCategoryViewModel vm)
		{
			SouvenirCategory category = Mapper.Mapp<SouvenirCategoryViewModel, SouvenirCategory>(vm);
			SouvenirCategory updatedCategory = DataManager.Update(category);

			var response = Mapper.Mapp<SouvenirCategory, SouvenirCategoryViewModel>(updatedCategory);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			SouvenirCategory category = DataManager.Delete(id);

			if (category == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<SouvenirCategory, SouvenirCategoryViewModel>(category);

			return Ok(response);
		}
	}
}
