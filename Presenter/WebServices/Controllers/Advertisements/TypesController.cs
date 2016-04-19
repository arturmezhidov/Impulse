using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using Impulse.Common.Components;
using Impulse.Common.Models.Advertisements;
using WebServices.Filters;
using WebServices.Models.Advertisements;

namespace WebServices.Controllers.Advertisements
{
	[RoutePrefix("api/advertisements/types")]
	public class TypesController : BaseApiController
	{
		protected ITypeManager DataManager;

		public TypesController(ITypeManager dataManager) : base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(TypeViewModel vm)
		{
			Type newType = Mapper.Mapp<TypeViewModel, Type>(vm);
			Type createdType = DataManager.Create(newType);

			var response = Mapper.Mapp<Type, TypeViewModel>(createdType);

			return Created("api/advertisements/types/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var types = DataManager.GetAll();

			var response = Mapper.MappCollection<Type, TypeViewModel>(types);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}")]
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
		[Route("{id:int}/adverts")]
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
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<TypeViewModel> vms)
		{
			IEnumerable<Type> types = Mapper.MappCollection<TypeViewModel, Type>(vms);
			IEnumerable<Type> updatedTypes = DataManager.Update(types);

			var response = Mapper.MappCollection<Type, TypeViewModel>(updatedTypes);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
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