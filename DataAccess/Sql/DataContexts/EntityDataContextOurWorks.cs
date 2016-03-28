﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.OurWorks;

namespace Impulse.DataAccess.Sql.DataContexts
{
	public partial class EntityDataContext
	{
		public DbSet<Item> WorkItems { get; set; }
		public DbSet<Category> WorkItemCategories { get; set; }
	}
}