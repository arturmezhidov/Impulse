using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Services;
using Impulse.Common.Components;
using Impulse.Common.Models.Services;
using WebServices.Filters;
using WebServices.Models.Services;

namespace WebServices.Controllers.Services
{
	[RoutePrefix("api/services/services")]
	public class ServicesController : BaseApiController
	{
		protected IServiceManager DataManager;

		public ServicesController(IServiceManager dataManager) : base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(ServiceViewModel vm)
		{
			Service newService = Mapper.Mapp<ServiceViewModel, Service>(vm);
			Service createdService = DataManager.Create(newService);

			var response = Mapper.Mapp<Service, ServiceViewModel>(createdService);

			return Created("api/services/services/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var services = DataManager.GetAll();

			var response = Mapper.MappCollection<Service, ServiceViewModel>(services);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult GetById(int id)
		{
			var service = DataManager.GetById(id);

			if (service == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Service, ServiceViewModel>(service);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<ServiceViewModel> vms)
		{
			IEnumerable<Service> services = Mapper.MappCollection<ServiceViewModel, Service>(vms);
			IEnumerable<Service> updatedServices = DataManager.Update(services);

			var response = Mapper.MappCollection<Service, ServiceViewModel>(updatedServices);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			var service = DataManager.Delete(id);

			if (service == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Service, ServiceViewModel>(service);

			return Ok(response);
		}
	}
}