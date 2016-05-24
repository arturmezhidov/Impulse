using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Services;
using Impulse.Common.Components;
using Impulse.Common.Models;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Filters;
using Impulse.Presenter.WebServices.Models.Services;

namespace Impulse.Presenter.WebServices.Controllers.Services
{
	[RoutePrefix("api/servies/categories")]
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
			ServiceCategory newCategory = Mapper.Mapp<CategoryViewModel, ServiceCategory>(vm);
			ServiceCategory createdCategory = DataManager.Create(newCategory);

			var response = Mapper.Mapp<ServiceCategory, CategoryViewModel>(createdCategory);

			return Created("api/servies/categories/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var categories = DataManager.GetAll();

			var response = Mapper.MappCollection<ServiceCategory, CategoryViewModel>(categories);

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

			var response = Mapper.Mapp<ServiceCategory, CategoryViewModel>(category);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}/servies")]
		public IHttpActionResult GetServicesByCategory(int id)
		{
			var category = DataManager.GetById(id);

			if (category == null)
			{
				return NotFound();
			}

			var response = Mapper.MappCollection<Service, ServiceViewModel>(category.Services);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(CategoryViewModel vm)
		{
			ServiceCategory category = Mapper.Mapp<CategoryViewModel, ServiceCategory>(vm);
			ServiceCategory updatedCategory = DataManager.Update(category);

			var response = Mapper.Mapp<ServiceCategory, CategoryViewModel>(updatedCategory);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			ServiceCategory category = DataManager.Delete(id);

			if (category == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<ServiceCategory, CategoryViewModel>(category);

			return Ok(response);
		}
	}
}
