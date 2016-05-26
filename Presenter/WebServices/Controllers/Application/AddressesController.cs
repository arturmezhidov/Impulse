using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Components;
using Impulse.Common.Models;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Filters;
using Impulse.Presenter.WebServices.Models.Application;

namespace Impulse.Presenter.WebServices.Controllers.Application
{
	[RoutePrefix("api/contacts/addresses")]
	public class AddressesController : BaseApiController
	{
		protected IAddressService DataService;

		public AddressesController(IAddressService dataService)
			: base(dataService)
		{
			DataService = dataService;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(AddressViewModel vm)
		{
			Address newItem = Mapper.Mapp<AddressViewModel, Address>(vm);
			Address createdItem = DataService.Create(newItem);

			var response = Mapper.Mapp<Address, AddressViewModel>(createdItem);

			return Created("api/contacts/addresses/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var items = DataService.GetAll();

			var response = Mapper.MappCollection<Address, AddressViewModel>(items);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult GetById(int id)
		{
			var item = DataService.GetById(id);

			if (item == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Address, AddressViewModel>(item);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<AddressViewModel> vms)
		{
			IEnumerable<Address> items = Mapper.MappCollection<AddressViewModel, Address>(vms);
			IEnumerable<Address> updatedItems = DataService.Update(items);

			var response = Mapper.MappCollection<Address, AddressViewModel>(updatedItems);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			var item = DataService.Delete(id);

			if (item == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Address, AddressViewModel>(item);

			return Ok(response);
		}
	}
}