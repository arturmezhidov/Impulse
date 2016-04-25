using System.Linq;
using Impulse.BusinessLogic.BusinessContracts.OurWorks;
using Impulse.Common.Models.OurWorks;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.OurWorks
{
	public class FolderManager : DataManager<Folder>, IFolderManager
	{
		protected IUnitOfWorkOurWorks unitOfWork;

		public FolderManager(IUnitOfWorkOurWorks unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public override IQueryable<Folder> GetAll()
		{
			return unitOfWork.Folders.GetAll().Where(i => !i.IsDeleted).OrderBy(i => i.SortingNumber);
		}

		protected override bool IsNewItem(Folder item)
		{
			return item.Id <= 0;
		}
	}
}