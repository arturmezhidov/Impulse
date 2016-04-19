using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Photography;
using Impulse.Common.Components;
using Impulse.Common.Models.Photography;
using WebServices.Filters;
using WebServices.Models.Photography;

namespace WebServices.Controllers.Photography
{
	[RoutePrefix("api/photographies/services")]
	public class PhotoServicesController : BaseApiController
	{
		protected IPhotoServiceManager DataManager;

		public PhotoServicesController(IPhotoServiceManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(PhotoServiceViewModel vm)
		{
			PhotoService newItem = Mapper.Mapp<PhotoServiceViewModel, PhotoService>(vm);
			PhotoService createdItem = DataManager.Create(newItem);

			var response = Mapper.Mapp<PhotoService, PhotoServiceViewModel>(createdItem);

			return Created("api/photographies/services/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var items = DataManager.GetAll();

			var response = Mapper.MappCollection<PhotoService, PhotoServiceViewModel>(items);

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

			var response = Mapper.Mapp<PhotoService, PhotoServiceViewModel>(item);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(PhotoServiceViewModel vm)
		{
			PhotoService item = Mapper.Mapp<PhotoServiceViewModel, PhotoService>(vm);
			PhotoService updatedItem = DataManager.Update(item);

			var response = Mapper.Mapp<PhotoService, PhotoServiceViewModel>(updatedItem);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			PhotoService item = DataManager.Delete(id);

			if (item == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<PhotoService, PhotoServiceViewModel>(item);

			return Ok(response);
		}
	}
}
