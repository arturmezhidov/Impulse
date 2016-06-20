using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Components;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.OurWorks;

namespace Impulse.Presenter.WebServices.Controllers.OurWorks
{
	public class OurWorksFoldersController : BaseApiController<OurWorksFolder, OurWorksFolderViewModel>
	{
		protected IOurWorksFolderService BusinessService;

		public OurWorksFoldersController(IOurWorksFolderService service)
			: base(service)
		{
			BusinessService = service;
		}

		protected override OurWorksFolderViewModel ToViewModel(OurWorksFolder model)
		{
			var result = base.ToViewModel(model);
			var items = Mapper.MappCollection<OurWorksItem, OurWorksItemViewModel>(model.OurWorksItems);

			result.Items.AddRange(items);

			return result;
		}
	}
}