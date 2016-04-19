using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Contacts;
using Impulse.Common.Components;
using Impulse.Common.Models.Contacts;
using WebServices.Filters;
using WebServices.Models.Contacts;

namespace WebServices.Controllers.Contacts
{
	[RoutePrefix("api/contacts/phones")]
	public class PhonesController : BaseApiController
	{
		protected IPhoneManager DataManager;

		public PhonesController(IPhoneManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(PhoneViewModel vm)
		{
			Phone newItem = Mapper.Mapp<PhoneViewModel, Phone>(vm);
			Phone createdItem = DataManager.Create(newItem);

			var response = Mapper.Mapp<Phone, PhoneViewModel>(createdItem);

			return Created("api/contacts/phones/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var items = DataManager.GetAll();

			var response = Mapper.MappCollection<Phone, PhoneViewModel>(items);

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

			var response = Mapper.Mapp<Phone, PhoneViewModel>(item);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<PhoneViewModel> vms)
		{
			IEnumerable<Phone> items = Mapper.MappCollection<PhoneViewModel, Phone>(vms);
			IEnumerable<Phone> updatedItems = DataManager.Update(items);

			var response = Mapper.MappCollection<Phone, PhoneViewModel>(updatedItems);

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

			var response = Mapper.Mapp<Phone, PhoneViewModel>(item);

			return Ok(response);
		}
	}
}