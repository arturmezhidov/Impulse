using System.Linq;
using Impulse.BusinessLogic.BusinessContracts.Photography;
using Impulse.Common.Models.Photography;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Photography
{
	public class PhotoServiceManager : DataManager<PhotoService>, IPhotoServiceManager
	{
		protected IUnitOfWorkPhotography unitOfWork;

		public PhotoServiceManager(IUnitOfWorkPhotography unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public override IQueryable<PhotoService> GetAll()
		{
			return unitOfWork.PhotoServices.GetAll().Where(i => !i.IsDeleted).OrderBy(i => i.SortingNumber);
		}

		protected override bool IsNewItem(PhotoService item)
		{
			return item.Id <= 0;
		}
	}
}