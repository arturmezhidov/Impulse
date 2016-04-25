using System.Data.Entity;
using Impulse.Common.Models.Application;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public class ApplicationDataContext : DbContext
	{
		public DbSet<ProfileUser> ProfilesUsers { get; set; }

		public ApplicationDataContext(string stringConnection) : base(stringConnection) { }
	}
}