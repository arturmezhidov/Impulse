using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Stends;
using Impulse.Common.Components;
using Impulse.Common.Models.Stends;
using WebServices.Filters;
using WebServices.Models.Stends;

namespace WebServices.Controllers.Stends
{
	[RoutePrefix("api/stends/stends")]
	public class StendsController : BaseApiController
	{
		protected IStendManager DataManager;

		public StendsController(IStendManager dataManager) : base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(StendViewModel vm)
		{
			Stend newStend = Mapper.Mapp<StendViewModel, Stend>(vm);
			Stend createdStend = DataManager.Create(newStend);

			var response = Mapper.Mapp<Stend, StendViewModel>(createdStend);

			return Created("api/stends/stends/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var stends = DataManager.GetAll();

			var response = Mapper.MappCollection<Stend, StendViewModel>(stends);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult GetById(int id)
		{
			var stend = DataManager.GetById(id);

			if (stend == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Stend, StendViewModel>(stend);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<StendViewModel> vms)
		{
			IEnumerable<Stend> stends = Mapper.MappCollection<StendViewModel, Stend>(vms);
			IEnumerable<Stend> updatedStends = DataManager.Update(stends);

			var response = Mapper.MappCollection<Stend, StendViewModel>(updatedStends);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			var stend = DataManager.Delete(id);

			if (stend == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Stend, StendViewModel>(stend);

			return Ok(response);
		}
	}
}