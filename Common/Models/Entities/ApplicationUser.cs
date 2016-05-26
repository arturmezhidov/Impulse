using Microsoft.AspNet.Identity.EntityFramework;

namespace Impulse.Common.Models.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public int ProfileUserId { get; set; }
		public ProfileUser ProfileUser { get; set; }
	}
}
