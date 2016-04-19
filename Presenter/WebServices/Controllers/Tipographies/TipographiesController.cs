using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Tipographies;
using Impulse.Common.Components;
using Impulse.Common.Models.Tipographies;
using WebServices.Filters;
using WebServices.Models.Tipographies;

namespace WebServices.Controllers.Tipographies
{
	[RoutePrefix("api/tipographies/tipographies")]
	public class TipographysController : BaseApiController
	{
		protected ITipographyManager DataManager;

		public TipographysController(ITipographyManager dataManager) : base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(TipographyViewModel vm)
		{
			Tipography newTipography = Mapper.Mapp<TipographyViewModel, Tipography>(vm);
			Tipography createdTipography = DataManager.Create(newTipography);

			var response = Mapper.Mapp<Tipography, TipographyViewModel>(createdTipography);

			return Created("api/tipographies/tipographies/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var tipographies = DataManager.GetAll();

			var response = Mapper.MappCollection<Tipography, TipographyViewModel>(tipographies);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult GetById(int id)
		{
			var tipography = DataManager.GetById(id);

			if (tipography == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Tipography, TipographyViewModel>(tipography);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<TipographyViewModel> vms)
		{
			IEnumerable<Tipography> tipographies = Mapper.MappCollection<TipographyViewModel, Tipography>(vms);
			IEnumerable<Tipography> updatedTipographys = DataManager.Update(tipographies);

			var response = Mapper.MappCollection<Tipography, TipographyViewModel>(updatedTipographys);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			var tipography = DataManager.Delete(id);

			if (tipography == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Tipography, TipographyViewModel>(tipography);

			return Ok(response);
		}
	}
}