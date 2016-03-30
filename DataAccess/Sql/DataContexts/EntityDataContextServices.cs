using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Services;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public partial class ApplicationDataContext
	{
		public DbSet<Service> Services { get; set; }
		public DbSet<Category> ServicesCategories { get; set; }
	}
}