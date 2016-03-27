using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Contacts;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public partial class EntityDataContext
	{
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Email> Emails { get; set; }
		public DbSet<Phone> Phones { get; set; }
		public DbSet<Social> Socials { get; set; }
	}
}