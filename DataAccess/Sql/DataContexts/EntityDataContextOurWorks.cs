using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.OurWorks;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public partial class EntityDataContext
	{
		public DbSet<WorkItem> WorkItems { get; set; }
		public DbSet<WorkItemsCategory> WorkItemCategories { get; set; }
	}
}