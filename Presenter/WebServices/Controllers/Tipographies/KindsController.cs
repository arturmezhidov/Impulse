using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.Tipographies;
using Impulse.Common.Components;
using Impulse.Common.Models.Tipographies;
using WebServices.Filters;
using WebServices.Models.Tipographies;

namespace WebServices.Controllers.Tipographies
{
	[RoutePrefix("api/tipographies/kinds")]
	public class KindsController : BaseApiController
	{
		protected IKindManager DataManager;

		public KindsController(IKindManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(KindViewModel vm)
		{
			Kind newKind = Mapper.Mapp<KindViewModel, Kind>(vm);
			Kind createdKind = DataManager.Create(newKind);

			var response = Mapper.Mapp<Kind, KindViewModel>(createdKind);

			return Created("api/tipographies/kinds/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var kinds = DataManager.GetAll();

			var response = Mapper.MappCollection<Kind, KindViewModel>(kinds);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult GetById(int id)
		{
			var category = DataManager.GetById(id);

			if (category == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Kind, KindViewModel>(category);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}/tipographies")]
		public IHttpActionResult GetServicesByKind(int id)
		{
			var category = DataManager.GetById(id);

			if (category == null)
			{
				return NotFound();
			}

			var response = Mapper.MappCollection<Tipography, TipographyViewModel>(category.Tipographies);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(KindViewModel vm)
		{
			Kind category = Mapper.Mapp<KindViewModel, Kind>(vm);
			Kind updatedKind = DataManager.Update(category);

			var response = Mapper.Mapp<Kind, KindViewModel>(updatedKind);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			Kind category = DataManager.Delete(id);

			if (category == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Kind, KindViewModel>(category);

			return Ok(response);
		}
	}
}
