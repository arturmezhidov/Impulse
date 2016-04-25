using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Impulse.Presenter.AuthOwin.Models
{
	class DbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			foreach (string role in Enum.GetNames(typeof(SystemRoles)))
			{
				context.Roles.Add(new IdentityRole { Name = role });
			}

			context.SaveChanges();
		}
	}
}
