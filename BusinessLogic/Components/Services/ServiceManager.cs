using System.Linq;
using Impulse.BusinessLogic.BusinessContracts.Services;
using Impulse.Common.Models.Services;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Services
{
	public class ServiceManager : DataManager<Service>, IServiceManager
	{
		protected IUnitOfWorkServices unitOfWork;

		public ServiceManager(IUnitOfWorkServices unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public override IQueryable<Service> GetAll()
		{
			return unitOfWork.Services.GetAll().Where(i => !i.IsDeleted).OrderBy(i => i.SortingNumber);
		}

		protected override bool IsNewItem(Service item)
		{
			return item.Id <= 0;
		}
	}
}