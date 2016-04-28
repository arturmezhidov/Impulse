using System.Linq;
using Impulse.Common.Models;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class SorterManager<T> : DataManager<T> where T : BaseItem, ISortable, new()
	{
		public SorterManager(IUnitOfWork uow) : base(uow)
		{
		}

		public override IQueryable<T> GetAll()
		{
			return base.GetAll().OrderBy(i => i.SortingNumber);
		}
	}
}
