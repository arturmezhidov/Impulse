using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Tipographies;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public partial class EntityDataContext
	{
		public DbSet<Tipography> Tipographies { get; set; }
		public DbSet<TipographiesCategory> TipographiesCategories { get; set; }
	}
}