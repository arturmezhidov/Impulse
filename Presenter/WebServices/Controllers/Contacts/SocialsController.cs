using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Contacts;
using Impulse.Common.Components;
using Impulse.Common.Models.Contacts;
using WebServices.Filters;
using WebServices.Models.Contacts;

namespace WebServices.Controllers.Contacts
{
	[RoutePrefix("api/contacts/socials")]
	public class SocialsController : BaseApiController
	{
		protected ISocialManager DataManager;

		public SocialsController(ISocialManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(SocialViewModel vm)
		{
			Social newItem = Mapper.Mapp<SocialViewModel, Social>(vm);
			Social createdItem = DataManager.Create(newItem);

			var response = Mapper.Mapp<Social, SocialViewModel>(createdItem);

			return Created("api/contacts/socials/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var items = DataManager.GetAll();

			var response = Mapper.MappCollection<Social, SocialViewModel>(items);

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

			var response = Mapper.Mapp<Social, SocialViewModel>(item);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<SocialViewModel> vms)
		{
			IEnumerable<Social> items = Mapper.MappCollection<SocialViewModel, Social>(vms);
			IEnumerable<Social> updatedItems = DataManager.Update(items);

			var response = Mapper.MappCollection<Social, SocialViewModel>(updatedItems);

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

			var response = Mapper.Mapp<Social, SocialViewModel>(item);

			return Ok(response);
		}
	}
}