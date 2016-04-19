using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Contacts;
using Impulse.Common.Components;
using Impulse.Common.Models.Contacts;
using WebServices.Filters;
using WebServices.Models.Contacts;

namespace WebServices.Controllers.Contacts
{
	[RoutePrefix("api/contacts/addresses")]
	public class AddressesController : BaseApiController
	{
		protected IAddressManager DataManager;

		public AddressesController(IAddressManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(AddressViewModel vm)
		{
			Address newItem = Mapper.Mapp<AddressViewModel, Address>(vm);
			Address createdItem = DataManager.Create(newItem);

			var response = Mapper.Mapp<Address, AddressViewModel>(createdItem);

			return Created("api/contacts/addresses/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var items = DataManager.GetAll();

			var response = Mapper.MappCollection<Address, AddressViewModel>(items);

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

			var response = Mapper.Mapp<Address, AddressViewModel>(item);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<AddressViewModel> vms)
		{
			IEnumerable<Address> items = Mapper.MappCollection<AddressViewModel, Address>(vms);
			IEnumerable<Address> updatedItems = DataManager.Update(items);

			var response = Mapper.MappCollection<Address, AddressViewModel>(updatedItems);

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

			var response = Mapper.Mapp<Address, AddressViewModel>(item);

			return Ok(response);
		}
	}
}