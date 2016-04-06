using System;
using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using Impulse.DataAccess.DataContracts;
using Type = Impulse.Common.Models.Advertisements.Type;

namespace Impulse.BusinessLogic.Components.Advertisements
{
	public class TypeDataManager : DataManager<Type>, ITypeDataManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public TypeDataManager(IUnitOfWorkAdvertisements unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool Contains(Type item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			bool result = (item.Id > 0) && (unitOfWork.Types.GetById(item.Id) != null);

			return result;
		}
	}
}