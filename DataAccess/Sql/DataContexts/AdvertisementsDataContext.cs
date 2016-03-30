using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Advertisements;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class AdvertisementsDataContext : DbContext
	{
		public DbSet<Advert> Adverts { get; set; }
		public DbSet<Type> Types { get; set; }
		public DbSet<Material> Materials { get; set; }

		public AdvertisementsDataContext(string stringConnection) : base(stringConnection) { }
	}
}