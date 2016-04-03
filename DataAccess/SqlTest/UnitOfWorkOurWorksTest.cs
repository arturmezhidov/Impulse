using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.Common.Models.OurWorks;
using System.Collections.Generic;
using Impulse.DataAccess.Sql.Repositories;

namespace SqlTest
{
	[TestClass]
	public class UnitOfWorkOurWorksTest
	{
		public const string ConnectionString = "DbContextTestConnectionString";
		public const int CategoriesCount = 100;
		public const int ItemsCount = 100;
		public const string UpdateKey = " - updated";

		[TestMethod]
		public void AddCategories()
		{
			using (var db = new OurWorksDataContext(ConnectionString))
			{
				int startItemsCount = db.Folders.Count();

				for (int i = 1; i <= CategoriesCount; i++)
				{
					db.Folders.Add(new Folder
					{
						Name = "name" + i,
						Description = "description" + i,
						Icon = "icon" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(CategoriesCount, db.Folders.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddItems()
		{
			using (var db = new OurWorksDataContext(ConnectionString))
			{
				int startItemsCount = db.Items.Count();
				var categories = db.Folders.ToArray();
				var addedCategories = new List<Folder>();
				var addedItems = new List<Item>();

				for (int i = 1; i <= ItemsCount; i++)
				{
					var folder = categories[i % (categories.Length - 1)];
					var item = new Item
					{
						Name = "name" + i,
						Description = "description" + i,
						Image = "image" + i,
						Folder = folder
					};

					db.Items.Add(item);
					db.SaveChanges();

					addedCategories.Add(folder);
					addedItems.Add(item);
				}

				Assert.AreEqual(ItemsCount, db.Items.Count() - startItemsCount);

				for (int i = 0; i < ItemsCount; i++)
				{
					var addedItem = addedItems[i];
					var item = db.Items.FirstOrDefault(a => a.Id == addedItem.Id);
					Assert.IsNotNull(item, "item = null");
					Assert.IsNotNull(item.Folder, "item.Folder = null");

					var folder = db.Folders.FirstOrDefault(c => c.Id == addedItem.Folder.Id);
					Assert.IsNotNull(folder, "folder = null");
				}
			}
		}

		[TestMethod]
		public void UpdateCategories()
		{
			using (var db = new OurWorksDataContext(ConnectionString))
			{
				foreach (var item in db.Folders)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Icon = item.Icon + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.Folders)
				{
					Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Icon.EndsWith(UpdateKey), "item.Icon.EndsWith(UpdateKey)");
				}
			}
		}
		[TestMethod]
		public void UpdateItems()
		{
				using (var db = new OurWorksDataContext(ConnectionString))
				{
					foreach (var item in db.Items)
					{
						item.Name = item.Name + UpdateKey;
						item.Description = item.Description + UpdateKey;
						item.Image = item.Image + UpdateKey;

						db.Entry(item).State = EntityState.Modified;
					}

					db.SaveChanges();

					foreach (var item in db.Items)
					{
						Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Image.EndsWith(UpdateKey), "item.Image.EndsWith(UpdateKey)");
					}

					var random = new Random();
					var categories = db.Folders.ToArray();
					var items = db.Items.ToArray();

					for (int i = 0; i < items.Length; i++)
					{
						var folderIndex = random.Next(0, categories.Length - 1);
						var folder = categories[folderIndex];
						var item = items[i];

						item.Folder = folder;

						db.Entry(item).State = EntityState.Modified;
						db.SaveChanges();

						var itemModify = db.Items.FirstOrDefault(a => a.Id == item.Id);
						Assert.IsNotNull(itemModify, "itemModify = null");
						Assert.IsNotNull(itemModify.Folder, "itemModify.Folder = null");
						Assert.AreEqual(item.Folder.Id, itemModify.Folder.Id, "item.Folder.Id, itemModify.Folder.Id");
					}
				}
		}

		[TestMethod]
		public void RemoveCategories()
		{
			using (var db = new OurWorksDataContext(ConnectionString))
			{
				int startItemsCount = db.Folders.Count();
				var item = db.Folders.FirstOrDefault();

				if (item != null)
				{
					db.Folders.Remove(item);
					db.SaveChanges();

					var removedItem = db.Folders.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Folders.Count());
				}
			}
		}
		[TestMethod]
		public void RemoveItems()
		{
			using (var db = new OurWorksDataContext(ConnectionString))
			{
				int startItemsCount = db.Items.Count();
				var item = db.Items.FirstOrDefault();

				if (item != null)
				{
					db.Items.Remove(item);
					db.SaveChanges();

					var removedItem = db.Items.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Items.Count());
				}
			}
		}
	}
}