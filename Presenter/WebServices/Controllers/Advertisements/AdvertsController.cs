using System.Web.Http;
using Impulse.Common.Components;
using Impulse.Presenter.WebServices.Filters;
using Impulse.Presenter.WebServices.Models.Advertisements;

namespace Impulse.Presenter.WebServices.Controllers.Advertisements
{
	//[RoutePrefix("api/advertisements/adverts")]
	//public class AdvertsController : BaseApiController
	//{
	//	protected IAdvertManager DataManager;

	//	public AdvertsController(IAdvertManager dataManager)
	//		: base(dataManager)
	//	{
	//		DataManager = dataManager;
	//	}

	//	[HttpPost]
	//	[Route("")]
	//	[ModelCheck]
	//	public IHttpActionResult Create(AdvertViewModel vm)
	//	{
	//		Advert newAdvert = Mapper.Mapp<AdvertViewModel, Advert>(vm);
	//		Advert createdAdvert = DataManager.Create(newAdvert);

	//		var response = Mapper.Mapp<Advert, AdvertViewModel>(createdAdvert);

	//		return Created("api/advertisements/adverts/" + response.Id, response);
	//	}

	//	[HttpGet]
	//	[Route("")]
	//	public IHttpActionResult GetAll()
	//	{
	//		var adverts = DataManager.GetAll();

	//		var response = Mapper.MappCollection<Advert, AdvertViewModel>(adverts);

	//		return Ok(response);
	//	}

	//	[HttpGet]
	//	[Route("{id:int}")]
	//	public IHttpActionResult GetById(int id)
	//	{
	//		var advert = DataManager.GetById(id);

	//		if (advert == null)
	//		{
	//			return NotFound();
	//		}

	//		var response = Mapper.Mapp<Advert, AdvertViewModel>(advert);

	//		return Ok(response);
	//	}

	//	[HttpPut]
	//	[Route("")]
	//	[ModelCheck]
	//	public IHttpActionResult Update(AdvertViewModel vm)
	//	{
	//		Advert advert = Mapper.Mapp<AdvertViewModel, Advert>(vm);
	//		Advert updatedAdvert = DataManager.Update(advert);

	//		var response = Mapper.Mapp<Advert, AdvertViewModel>(updatedAdvert);

	//		return Ok(response);
	//	}

	//	[HttpDelete]
	//	[Route("{id:int}")]
	//	public IHttpActionResult Delete(int id)
	//	{
	//		Advert advert = DataManager.Delete(id);

	//		if (advert == null)
	//		{
	//			return NotFound();
	//		}

	//		var response = Mapper.Mapp<Advert, AdvertViewModel>(advert);

	//		return Ok(response);
	//	}
	//}
}
