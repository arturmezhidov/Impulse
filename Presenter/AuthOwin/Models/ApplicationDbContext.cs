using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Impulse.Presenter.AuthOwin.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public static string ConntectionString { get; set; }

		public ApplicationDbContext(string connectionString)
			: base(connectionString, throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext(ConntectionString);
		}

		static ApplicationDbContext()
		{
			//Database.SetInitializer(new DbInitializer());
		}
	}
}
