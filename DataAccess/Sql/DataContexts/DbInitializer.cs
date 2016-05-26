using System;
using System.Data.Entity;
using Impulse.Common.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Impulse.DataAccess.Sql.DataContexts
{
	class DbInitializer : CreateDatabaseIfNotExists<EntityDataContext>
	{
		protected override void Seed(EntityDataContext context)
		{
			foreach (string role in Enum.GetNames(typeof(SystemRoles)))
			{
				context.Roles.Add(new IdentityRole { Name = role });
			}

			context.SaveChanges();
		}
	}
}
