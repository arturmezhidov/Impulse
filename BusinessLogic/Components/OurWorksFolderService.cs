using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class OurWorksFolderService : SorterService<OurWorksFolder>, IOurWorksFolderService
	{
		public OurWorksFolderService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}