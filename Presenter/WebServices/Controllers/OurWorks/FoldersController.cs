using System.Collections.Generic;
using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts.OurWorks;
using Impulse.Common.Components;
using Impulse.Common.Models.OurWorks;
using Impulse.Presenter.WebServices.Filters;
using Impulse.Presenter.WebServices.Models.OurWorks;

namespace Impulse.Presenter.WebServices.Controllers.OurWorks
{
	[RoutePrefix("api/ourworks/folders")]
	public class FoldersController : BaseApiController
	{
		protected IFolderManager DataManager;

		public FoldersController(IFolderManager dataManager) : base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(FolderViewModel vm)
		{
			Folder newItem = Mapper.Mapp<FolderViewModel, Folder>(vm);
			Folder createdItem = DataManager.Create(newItem);

			var response = Mapper.Mapp<Folder, FolderViewModel>(createdItem);

			return Created("api/ourworks/folders/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var folders = DataManager.GetAll();

			var response = Mapper.MappCollection<Folder, FolderViewModel>(folders);

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

			var response = Mapper.Mapp<Folder, FolderViewModel>(item);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}/items")]
		public IHttpActionResult GetItemsByFolder(int id)
		{
			var item = DataManager.GetById(id);

			if (item == null)
			{
				return NotFound();
			}

			var response = Mapper.MappCollection<Item, ItemViewModel>(item.Items);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<FolderViewModel> vms)
		{
			IEnumerable<Folder> items = Mapper.MappCollection<FolderViewModel, Folder>(vms);
			IEnumerable<Folder> updatedItems = DataManager.Update(items);

			var response = Mapper.MappCollection<Folder, FolderViewModel>(updatedItems);

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

			var response = Mapper.Mapp<Folder, FolderViewModel>(item);

			return Ok(response);
		}
	}
}