using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Photography;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class PhotographyDataContext : DbContext
	{
		public DbSet<PhotoService> PhotoServices { get; set; }

		public PhotographyDataContext(string stringConnection) : base(stringConnection) { }
	}
}