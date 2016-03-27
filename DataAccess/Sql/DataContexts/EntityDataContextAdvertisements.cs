using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Advertisements;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public partial class EntityDataContext
	{
		public DbSet<Advert> Adverts { get; set; }
		public DbSet<Category> AdvertsCategories { get; set; }
		public DbSet<Material> AdvertsMaterials { get; set; }
	}
}