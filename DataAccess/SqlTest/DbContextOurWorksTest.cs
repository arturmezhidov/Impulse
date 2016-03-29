﻿using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.Common.Models.OurWorks;
using System.Collections.Generic;
using Impulse.DataAccess.Contracts;
using Impulse.DataAccess.Sql.Repositories;

namespace SqlTest
{
	[TestClass]
	public class DbContextOurWorksTest
	{
		public const string ConnectionString = "DbContextTestConnectionString";
		public const int CategoriesCount = 100;
		public const int ItemsCount = 100;
		public const string UpdateKey = " - updated";

		[TestMethod]
		public void AddCategories()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.WorkItemsCategories.Count();

				for (int i = 1; i <= CategoriesCount; i++)
				{
					db.WorkItemsCategories.Add(new ItemsCategory
					{
						Name = "name" + i,
						Description = "description" + i,
						Icon = "icon" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(CategoriesCount, db.WorkItemsCategories.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddItems()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.WorkItems.Count();
				var categories = db.WorkItemsCategories.ToArray();
				var addedCategories = new List<ItemsCategory>();
				var addedItems = new List<Item>();

				for (int i = 1; i <= ItemsCount; i++)
				{
					var category = categories[i % (categories.Length - 1)];
					var item = new Item
					{
						Name = "name" + i,
						Description = "description" + i,
						Image = "image" + i,
						Category = category
					};

					db.WorkItems.Add(item);
					db.SaveChanges();

					addedCategories.Add(category);
					addedItems.Add(item);
				}

				Assert.AreEqual(ItemsCount, db.WorkItems.Count() - startItemsCount);

				for (int i = 0; i < ItemsCount; i++)
				{
					var addedItem = addedItems[i];
					var item = db.WorkItems.FirstOrDefault(a => a.Id == addedItem.Id);
					Assert.IsNotNull(item, "item = null");
					Assert.IsNotNull(item.Category, "item.Category = null");

					var category = db.WorkItemsCategories.FirstOrDefault(c => c.Id == addedItem.Category.Id);
					Assert.IsNotNull(category, "category = null");
				}
			}
		}

		[TestMethod]
		public void UpdateCategories()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				foreach (var item in db.WorkItemsCategories)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Icon = item.Icon + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.WorkItemsCategories)
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
				using (var db = new EntityDataContext(ConnectionString))
				{
					foreach (var item in db.WorkItems)
					{
						item.Name = item.Name + UpdateKey;
						item.Description = item.Description + UpdateKey;
						item.Image = item.Image + UpdateKey;

						db.Entry(item).State = EntityState.Modified;
					}

					db.SaveChanges();

					foreach (var item in db.WorkItems)
					{
						Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Image.EndsWith(UpdateKey), "item.Image.EndsWith(UpdateKey)");
					}

					var random = new Random();
					var categories = db.WorkItemsCategories.ToArray();
					var items = db.WorkItems.ToArray();

					for (int i = 0; i < items.Length; i++)
					{
						var categoryIndex = random.Next(0, categories.Length - 1);
						var category = categories[categoryIndex];
						var item = items[i];

						item.Category = category;

						db.Entry(item).State = EntityState.Modified;
						db.SaveChanges();

						var itemModify = db.WorkItems.FirstOrDefault(a => a.Id == item.Id);
						Assert.IsNotNull(itemModify, "itemModify = null");
						Assert.IsNotNull(itemModify.Category, "itemModify.Category = null");
						Assert.AreEqual(item.Category.Id, itemModify.Category.Id, "item.Category.Id, itemModify.Category.Id");
					}
				}
		}

		[TestMethod]
		public void RemoveCategories()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.WorkItemsCategories.Count();
				var item = db.WorkItemsCategories.FirstOrDefault();

				if (item != null)
				{
					db.WorkItemsCategories.Remove(item);
					db.SaveChanges();

					var removedItem = db.WorkItemsCategories.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.WorkItemsCategories.Count());
				}
			}
		}
		[TestMethod]
		public void RemoveItems()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.WorkItems.Count();
				var item = db.WorkItems.FirstOrDefault();

				if (item != null)
				{
					db.WorkItems.Remove(item);
					db.SaveChanges();

					var removedItem = db.WorkItems.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.WorkItems.Count());
				}
			}
		}
	}
}