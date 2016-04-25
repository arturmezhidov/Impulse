using Impulse.BusinessLogic.BusinessContracts.OurWorks;
using Impulse.Common.Models.OurWorks;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.OurWorks
{
	public class ItemManager : DataManager<Item>, IItemManager
	{
		protected IUnitOfWorkOurWorks unitOfWork;

		public ItemManager(IUnitOfWorkOurWorks unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override bool IsNewItem(Item item)
		{
			return item.Id <= 0;
		}
	}
}