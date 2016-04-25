using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Impulse.Presenter.AuthOwin.Models
{
	public class ApplicationUser : IdentityUser
	{
		public int ProfileUserId { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
		{
			var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
			return userIdentity;
		}
	}
}
