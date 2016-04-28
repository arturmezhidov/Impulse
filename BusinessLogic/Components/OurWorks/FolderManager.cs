using Impulse.BusinessLogic.BusinessContracts.OurWorks;
using Impulse.Common.Models.OurWorks;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.OurWorks
{
	public class FolderManager : SorterManager<Folder>, IFolderManager
	{
		protected IUnitOfWorkOurWorks unitOfWork;

		public FolderManager(IUnitOfWorkOurWorks unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}