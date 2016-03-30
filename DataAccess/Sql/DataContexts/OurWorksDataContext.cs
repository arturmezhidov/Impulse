using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.OurWorks;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class OurWorksDataContext : DbContext
	{
		public DbSet<Item> Items { get; set; }
		public DbSet<Folder> Folders { get; set; }

		public OurWorksDataContext(string stringConnection) : base(stringConnection) { }
	}
}