using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Souvenirs;
using Impulse.Common.Components;
using Impulse.Common.Models.Souvenirs;
using Impulse.Presenter.WebServices.Filters;
using Impulse.Presenter.WebServices.Models.Souvenirs;

namespace Impulse.Presenter.WebServices.Controllers.Souvenirs
{
	[RoutePrefix("api/souvenirs/souvenirs")]
	public class SouvenirsController : BaseApiController
	{
		protected ISouvenirManager DataManager;

		public SouvenirsController(ISouvenirManager dataManager) : base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(SouvenirViewModel vm)
		{
			Souvenir newSouvenir = Mapper.Mapp<SouvenirViewModel, Souvenir>(vm);
			Souvenir createdSouvenir = DataManager.Create(newSouvenir);

			var response = Mapper.Mapp<Souvenir, SouvenirViewModel>(createdSouvenir);

			return Created("api/souvenirs/souvenirs/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var souvenirs = DataManager.GetAll();

			var response = Mapper.MappCollection<Souvenir, SouvenirViewModel>(souvenirs);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult GetById(int id)
		{
			var souvenir = DataManager.GetById(id);

			if (souvenir == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Souvenir, SouvenirViewModel>(souvenir);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<SouvenirViewModel> vms)
		{
			IEnumerable<Souvenir> souvenirs = Mapper.MappCollection<SouvenirViewModel, Souvenir>(vms);
			IEnumerable<Souvenir> updatedSouvenirs = DataManager.Update(souvenirs);

			var response = Mapper.MappCollection<Souvenir, SouvenirViewModel>(updatedSouvenirs);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			var souvenir = DataManager.Delete(id);

			if (souvenir == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Souvenir, SouvenirViewModel>(souvenir);

			return Ok(response);
		}
	}
}