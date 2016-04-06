using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using Impulse.Common.Models.Advertisements;
using Impulse.Common.Components;
using WebServices.Models.Advertisements;

namespace WebServices.Controllers.Advertisements
{
	[RoutePrefix("api/advertisements")]
	public class TypesController : BaseApiController
	{
		protected ITypeDataManager DataManager;

		public TypesController(ITypeDataManager dataManager) : base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("types")]
		public IHttpActionResult Create(TypeViewModel vm)
		{
			if (vm == null)
			{
				return BadRequest();
			}
			else if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Type newType = Mapper.Mapp<TypeViewModel, Type>(vm);

			var response = DataManager.Create(newType);

			return Created("api/advertisements/types/" + response.Id, response);
		}

		[HttpGet]
		[Route("types")]
		public IHttpActionResult GetAll()
		{
			var types = DataManager.GetAll();

			var response = Mapper.MappCollection<Type, TypeViewModel>(types);

			return Ok(response);
		}

		[HttpGet]
		[Route("types/{id:int}")]
		public IHttpActionResult GetById(int id)
		{
			var type = DataManager.GetById(id);

			if (type == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Type, TypeViewModel>(type);

			return Ok(response);
		}

		[HttpGet]
		[Route("types/{id:int}/adverts")]
		public IHttpActionResult GetAdvertsByType(int id)
		{
			var type = DataManager.GetById(id);

			if (type == null)
			{
				return NotFound();
			}

			var response = Mapper.MappCollection<Advert, AdvertViewModel>(type.Adverts);

			return Ok(response);
		}

		[HttpPut]
		[Route("types/{id:int}")]
		public IHttpActionResult Update(TypeViewModel vm)
		{
			if (vm == null)
			{
				return BadRequest();
			}
			else if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Type type = Mapper.Mapp<TypeViewModel, Type>(vm);

			var response = DataManager.Update(type);

			return Created("api/advertisements/types/" + response.Id, response);
		}

		[HttpPut]
		[Route("types")]
		public IHttpActionResult Update(List<TypeViewModel> vms)
		{
			if (vms == null)
			{
				return BadRequest();
			}
			else if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			IEnumerable<Type> types = Mapper.MappCollection<TypeViewModel, Type>(vms);

			var response = DataManager.Update(types);

			return Created("api/advertisements/types", response);
		}

		[HttpDelete]
		[Route("types/{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			var type = DataManager.Delete(id);

			if (type == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Type, TypeViewModel>(type);

			return Ok(response);
		}
	}
}