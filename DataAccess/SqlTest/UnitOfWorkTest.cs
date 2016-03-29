using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Impulse.DataAccess.Sql.Repositories;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.Common.Models.Services;
using System.Collections.Generic;

namespace SqlTest
{
	[TestClass]
	public class UnitOfWorkTest
	{
		public const string ConnectionString = "DbContextTestConnectionString";

		[TestMethod]
		public void Add()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				var cat = new BaseRepository<ServicesCategory>(db);
				var ser = new BaseRepository<Service>(db);
				//db.Configuration.AutoDetectChangesEnabled = false;
				//for (int i = 0; i < 10000; i++)
				//{
				//repo.Add(new PhotoService()
				//{
				//	Name = "name" + i,
				//	Image = "image" + i,
				//	Description = "desc" + 1
				//});
				//}
				////db.Configuration.AutoDetectChangesEnabled = true;
				//db.SaveChanges();

				//var c = new ServicesCategory()
				//{
				//	Name = "name",
				//	Description = "desc",
				//	Icon = "icon"
				//};

				//c = cat.Add(c);

				//var item = ser.Add(new Service()
				//{
				//	Name = "name",
				//	Icon = "Icon",
				//	Description = "desc",
				//	Category = c
				//});


				var c = cat.GetById(10);
				var c2 = cat.GetById(11);
				var i = ser.GetById(202);
				var i2 = ser.GetById(203);



				i.Category = c;
				i2.Category = c2;

				//db.Configuration.AutoDetectChangesEnabled = true;

				ser.UpdateRange(new List<Service>() { i, i2 });
			}
		}
	}
}
