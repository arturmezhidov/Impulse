using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Tipographies;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class TipographiesDataContext : DbContext
	{
		public DbSet<Tipography> Tipographies { get; set; }
		public DbSet<Kind> Kinds { get; set; }

		public TipographiesDataContext(string stringConnection) : base(stringConnection) { }
	}
}