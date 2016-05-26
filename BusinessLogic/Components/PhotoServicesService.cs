using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class PhotoServicesService : SorterService<PhotoService>, IPhotoServicesService
	{
		public PhotoServicesService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}