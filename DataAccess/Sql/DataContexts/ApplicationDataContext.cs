using System.Data.Entity;
using Impulse.Common.Models.Application;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class ApplicationDataContext : DbContext
	{
		public DbSet<ProfileUser> ProfilesUsers { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Email> Emails { get; set; }
		public DbSet<Phone> Phones { get; set; }
		public DbSet<Social> Socials { get; set; }

		public ApplicationDataContext(string stringConnection) : base(stringConnection) { }
	}
}