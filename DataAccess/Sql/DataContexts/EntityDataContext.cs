using System.Data.Entity;
using Impulse.Common.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class EntityDataContext : IdentityDbContext<ApplicationUser>
	{
		public virtual DbSet<ProfileUser> ProfilesUsers { get; set; }
		public virtual DbSet<Address> Addresses { get; set; }
		public virtual DbSet<Email> Emails { get; set; }
		public virtual DbSet<Phone> Phones { get; set; }
		public virtual DbSet<Social> Socials { get; set; }
		public virtual DbSet<Slide> Slides { get; set; }

		public virtual DbSet<Advert> Adverts { get; set; }
		public virtual DbSet<AdvertsCategory> AdvertsCategories { get; set; }
		public virtual DbSet<AdvertsOrder> AdvertsOrders { get; set; }

		public virtual DbSet<Service> Services { get; set; }
		public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }
		public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

		public virtual DbSet<Souvenir> Souvenirs { get; set; }
		public virtual DbSet<SouvenirCategory> SouvenirCategories { get; set; }
		public virtual DbSet<SouvenirOrder> SouvenirOrders { get; set; }

		public virtual DbSet<Stend> Stends { get; set; }
		public virtual DbSet<StendCategory> StendCategories { get; set; }
		public virtual DbSet<StendOrder> StendOrders { get; set; }

		public virtual DbSet<Tipography> Tipographies { get; set; }
		public virtual DbSet<TipographyCategory> TipographyCategories { get; set; }

		public virtual DbSet<OurWorksItem> OurWorksItems { get; set; }
		public virtual DbSet<OurWorksFolder> OurWorksFolders { get; set; }

		public virtual DbSet<PhotoService> PhotoServices { get; set; }

		public EntityDataContext(string connectionString)
			: base(connectionString, throwIfV1Schema: false)
		{
		}

		static EntityDataContext()
		{
			Database.SetInitializer(new DbInitializer());
		}
	}
}