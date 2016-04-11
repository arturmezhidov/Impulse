using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using Impulse.Common.Components;
using Impulse.Common.Models.Advertisements;
using WebServices.Models.Advertisements;

namespace WebServices.Controllers.Advertisements
{
	[RoutePrefix("api/advertisements")]
	public class MaterialsController : BaseApiController
	{
		protected IMaterialManager DataManager;

		public MaterialsController(IMaterialManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("materials")]
		public IHttpActionResult Create(MaterialViewModel vm)
		{
			if (vm == null)
			{
				return BadRequest();
			}
			else if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Material newItem = Mapper.Mapp<MaterialViewModel, Material>(vm);
			Material createdItem = DataManager.Create(newItem);

			var response = Mapper.Mapp<Material, MaterialViewModel>(createdItem);

			return Created("api/advertisements/materials/" + response.Id, response);
		}

		[HttpGet]
		[Route("materials")]
		public IHttpActionResult GetAll()
		{
			var items = DataManager.GetAll();

			var response = Mapper.MappCollection<Material, MaterialViewModel>(items);

			return Ok(response);
		}

		[HttpGet]
		[Route("materials/{id:int}")]
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
		[Route("materials")]
		public IHttpActionResult Update(List<MaterialViewModel> vms)
		{
			if (vms == null)
			{
				return BadRequest();
			}
			else if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			IEnumerable<Material> items = Mapper.MappCollection<MaterialViewModel, Material>(vms);
			IEnumerable<Material> updatedItems = DataManager.Update(items);

			var response = Mapper.MappCollection<Material, MaterialViewModel>(updatedItems);

			return Ok(response);
		}

		[HttpDelete]
		[Route("materials/{id:int}")]
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