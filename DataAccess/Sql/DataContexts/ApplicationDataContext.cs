using System.Data.Entity;
using Impulse.Common.Models.Application;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class ApplicationDataContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<ProfileUser> ProfilesUsers { get; set; }

		public ApplicationDataContext(string stringConnection) : base(stringConnection) { }
	}
}