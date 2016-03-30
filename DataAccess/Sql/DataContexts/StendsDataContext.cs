using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Stends;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class StendsDataContext : DbContext
	{
		public DbSet<Stend> Stends { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Material> Materials { get; set; }

		public StendsDataContext(string stringConnection) : base(stringConnection) { }
	}
}