using Impulse.BusinessLogic.BusinessContracts.OurWorks;
using Impulse.Common.Models.OurWorks;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.OurWorks
{
	public class FolderManager : DataManager<Folder>, IFolderManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public FolderManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Folder item)
		{
			return item.Id <= 0;
		}
	}
}