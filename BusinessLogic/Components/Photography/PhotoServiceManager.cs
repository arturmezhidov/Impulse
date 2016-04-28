using Impulse.BusinessLogic.BusinessContracts.Photography;
using Impulse.Common.Models.Photography;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Photography
{
	public class PhotoServiceManager : SorterManager<PhotoService>, IPhotoServiceManager
	{
		protected IUnitOfWorkPhotography unitOfWork;

		public PhotoServiceManager(IUnitOfWorkPhotography unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}