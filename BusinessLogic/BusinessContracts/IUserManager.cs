using System;
using System.Threading.Tasks;
using Impulse.Common.Models.Entities;
using Microsoft.AspNet.Identity;

namespace Impulse.BusinessLogic.BusinessContracts
{
	public interface IUserManager : IDisposable
	{
		Task<ApplicationUser> FindByIdAsync(string userId);
		Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
		Task<IdentityResult> AddPasswordAsync(string userId, string password);
		Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
		Task<IdentityResult> RemovePasswordAsync(string userId);
		Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo login);
		Task<ApplicationUser> FindAsync(UserLoginInfo login);
	}
}