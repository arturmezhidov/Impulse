using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using Impulse.DataAccess.DataContracts;
using Type = Impulse.Common.Models.Advertisements.Type;

namespace Impulse.BusinessLogic.Components.Advertisements
{
	public class TypeManager : DataManager<Type>, ITypeManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public TypeManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Type item)
		{
			return item.Id <= 0;
		}
	}
}