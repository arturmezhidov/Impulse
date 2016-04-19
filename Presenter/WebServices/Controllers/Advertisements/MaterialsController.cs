using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using Impulse.Common.Components;
using Impulse.Common.Models.Advertisements;
using WebServices.Filters;
using WebServices.Models.Advertisements;

namespace WebServices.Controllers.Advertisements
{
	[RoutePrefix("api/advertisements/materials")]
	public class MaterialsController : BaseApiController
	{
		protected IMaterialManager DataManager;

		public MaterialsController(IMaterialManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(MaterialViewModel vm)
		{
			Material newItem = Mapper.Mapp<MaterialViewModel, Material>(vm);
			Material createdItem = DataManager.Create(newItem);

			var response = Mapper.Mapp<Material, MaterialViewModel>(createdItem);

			return Created("api/advertisements/materials/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var items = DataManager.GetAll();

			var response = Mapper.MappCollection<Material, MaterialViewModel>(items);

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

			var response = Mapper.Mapp<Material, MaterialViewModel>(item);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<MaterialViewModel> vms)
		{
			IEnumerable<Material> items = Mapper.MappCollection<MaterialViewModel, Material>(vms);
			IEnumerable<Material> updatedItems = DataManager.Update(items);

			var response = Mapper.MappCollection<Material, MaterialViewModel>(updatedItems);

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

			var response = Mapper.Mapp<Material, MaterialViewModel>(item);

			return Ok(response);
		}
	}
}