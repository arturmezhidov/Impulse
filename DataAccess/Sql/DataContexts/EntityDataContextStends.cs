using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Stends;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public partial class EntityDataContext
	{
		public DbSet<Stend> Stends { get; set; }
		public DbSet<StendsCategory> StendsCategories { get; set; }
		public DbSet<StendsMaterial> StendsMaterials { get; set; }
	}
}