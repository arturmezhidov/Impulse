using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.Common.Models.Photography;
using System.Collections.Generic;
using Impulse.DataAccess.Contracts;
using Impulse.DataAccess.Sql.Repositories;

namespace SqlTest
{
	[TestClass]
	public class DbContextPhotographyTest
	{
		public const string ConnectionString = "DbContextTestConnectionString";
		public const int PhotographyCount = 100;
		public const string UpdateKey = " - updated";

		[TestMethod]
		public void AddPhotography()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.PhotoServices.Count();

				for (int i = 1; i <= PhotographyCount; i++)
				{
					db.PhotoServices.Add(new PhotoService
					{
						Name = "name" + i,
						Description = "description" + i,
						Image = "image" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(PhotographyCount, db.PhotoServices.Count() - startItemsCount);
			}
		}
 
		[TestMethod]
		public void UpdatePhotography()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				foreach (var item in db.PhotoServices)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Image = item.Image + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.PhotoServices)
				{
					Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Image.EndsWith(UpdateKey), "item.Icon.EndsWith(UpdateKey)");
				}
			}
		}

		[TestMethod]
		public void RemovePhotography()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.PhotoServices.Count();
				var item = db.PhotoServices.FirstOrDefault();

				if (item != null)
				{
					db.PhotoServices.Remove(item);
					db.SaveChanges();

					var removedItem = db.PhotoServices.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.PhotoServices.Count());
				}
			}
		}
	}
}