using System;
using Impulse.Common.Models.Entities;
using Microsoft.AspNet.Identity;

namespace Impulse.BusinessLogic.BusinessContracts
{
	public interface IUserManager : IDisposable
	{
		IUserStore<ApplicationUser> GetUserStore();

		//Task<ApplicationUser> FindByIdAsync(string userId);
		//Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
		//Task<IdentityResult> AddPasswordAsync(string userId, string password);
		//Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
		//Task<IdentityResult> RemovePasswordAsync(string userId);
		//Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo login);
		//Task<ApplicationUser> FindAsync(UserLoginInfo login);
		//Task<ApplicationUser> FindAsync(string userName, string password);
		//Task<IdentityResult> CreateAsync(RegisterUser user);
		//Task<IdentityResult> CreateAsync(RegisterUser user, string password);
		//Task<IdentityResult> AddToRoleAsync(string userId, string role);
		//Task<IdentityResult> AddToRolesAsync(string userId, params string[] roles);
		//Task<IdentityResult> DeleteAsync(ApplicationUser user);
		//Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationType);
		//void SetUserTokenProvider(IUserTokenProvider<ApplicationUser, string> provider);
	}
}