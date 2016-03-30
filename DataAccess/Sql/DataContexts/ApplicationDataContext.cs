using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class ApplicationDataContext : DbContext
	{
		public ApplicationDataContext(string stringConnection) : base(stringConnection) { }
	}
}