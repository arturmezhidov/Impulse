using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Souvenirs;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public partial class EntityDataContext
	{
		public DbSet<Souvenir> Souvenirs { get; set; }
		public DbSet<SouvenirsCategory> SouvenirsCategories { get; set; }
	}
}