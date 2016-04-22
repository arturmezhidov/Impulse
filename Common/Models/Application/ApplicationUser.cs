using Microsoft.AspNet.Identity.EntityFramework;

namespace Impulse.Common.Models.Application
{
	public class ApplicationUser : IdentityUser
	{
		public int ProfileUserId { get; set; }
	}
}
