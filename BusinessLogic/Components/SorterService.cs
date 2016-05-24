using System.Linq;
using Impulse.Common.Models;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class SorterService<T> : DataService<T> where T : BaseEntity, ISortable, new()
	{
		public SorterService(IUnitOfWork uow)
			: base(uow)
		{
		}

		public override IQueryable<T> GetAll()
		{
			return base.GetAll().OrderBy(i => i.SortingNumber);
		}
	}
}
