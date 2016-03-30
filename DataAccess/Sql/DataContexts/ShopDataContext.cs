using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class ShopDataContext : DbContext
	{
		public ShopDataContext(string stringConnection) : base(stringConnection) { }
	}
}