using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.Repositories;
using Impulse.DataAccess.Sql.DataContexts;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class ShopUnitOfWork : UnitOfWork, IUnitOfWorkShop
	{
		public ShopUnitOfWork(string stringConnection)
			: base(new ShopDataContext(stringConnection))
		{
		}

		public override IRepository<T> GetRepository<T>()
		{
			return null;
		}
	}
}