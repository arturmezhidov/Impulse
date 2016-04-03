using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.Common.Models.Tipographies;
using System.Collections.Generic;
using Impulse.DataAccess.Sql.Repositories;

namespace SqlTest
{
	[TestClass]
	public class UnitOfWorkTipographiesTest
	{
		public const string ConnectionString = "DbContextTestConnectionString";
		public const int CategoriesCount = 100;
		public const int ItemsCount = 100;
		public const string UpdateKey = " - updated";

		[TestMethod]
		public void AddCategories()
		{
			using (var db = new TipographiesDataContext(ConnectionString))
			{
				int startItemsCount = db.Kinds.Count();

				for (int i = 1; i <= CategoriesCount; i++)
				{
					db.Kinds.Add(new Kind
					{
						Name = "name" + i,
						Description = "description" + i,
						Icon = "icon" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(CategoriesCount, db.Kinds.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddItems()
		{
			using (var db = new TipographiesDataContext(ConnectionString))
			{
				int startItemsCount = db.Tipographies.Count();
				var categories = db.Kinds.ToArray();
				var addedCategories = new List<Kind>();
				var addedItems = new List<Tipography>();

				for (int i = 1; i <= ItemsCount; i++)
				{
					var kind = categories[i % (categories.Length - 1)];
					var item = new Tipography
					{
						Name = "name" + i,
						Description = "description" + i,
						Image = "image" + i,
						Number = "number" + i,
						Kind = kind
					};

					db.Tipographies.Add(item);
					db.SaveChanges();

					addedCategories.Add(kind);
					addedItems.Add(item);
				}

				Assert.AreEqual(ItemsCount, db.Tipographies.Count() - startItemsCount);

				for (int i = 0; i < ItemsCount; i++)
				{
					var addedItem = addedItems[i];
					var item = db.Tipographies.FirstOrDefault(a => a.Id == addedItem.Id);
					Assert.IsNotNull(item, "item = null");
					Assert.IsNotNull(item.Kind, "item.Kind = null");

					var kind = db.Kinds.FirstOrDefault(c => c.Id == addedItem.Kind.Id);
					Assert.IsNotNull(kind, "kind = null");
				}
			}
		}

		[TestMethod]
		public void UpdateCategories()
		{
			using (var db = new TipographiesDataContext(ConnectionString))
			{
				foreach (var item in db.Kinds)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Icon = item.Icon + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.Kinds)
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
				using (var db = new TipographiesDataContext(ConnectionString))
				{
					foreach (var item in db.Tipographies)
					{
						item.Name = item.Name + UpdateKey;
						item.Description = item.Description + UpdateKey;
						item.Image = item.Image + UpdateKey;
						item.Number = item.Number + UpdateKey;

						db.Entry(item).State = EntityState.Modified;
					}

					db.SaveChanges();

					foreach (var item in db.Tipographies)
					{
						Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Image.EndsWith(UpdateKey), "item.Image.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Number.EndsWith(UpdateKey), "item.Number.EndsWith(UpdateKey)");
					}

					var random = new Random();
					var categories = db.Kinds.ToArray();
					var items = db.Tipographies.ToArray();

					for (int i = 0; i < items.Length; i++)
					{
						var kindIndex = random.Next(0, categories.Length - 1);
						var kind = categories[kindIndex];
						var item = items[i];

						item.Kind = kind;

						db.Entry(item).State = EntityState.Modified;
						db.SaveChanges();

						var itemModify = db.Tipographies.FirstOrDefault(a => a.Id == item.Id);
						Assert.IsNotNull(itemModify, "itemModify = null");
						Assert.IsNotNull(itemModify.Kind, "itemModify.Kind = null");
						Assert.AreEqual(item.Kind.Id, itemModify.Kind.Id, "item.Kind.Id, itemModify.Kind.Id");
					}
				}
		}

		[TestMethod]
		public void RemoveCategories()
		{
			using (var db = new TipographiesDataContext(ConnectionString))
			{
				int startItemsCount = db.Kinds.Count();
				var item = db.Kinds.FirstOrDefault();

				if (item != null)
				{
					db.Kinds.Remove(item);
					db.SaveChanges();

					var removedItem = db.Kinds.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Kinds.Count());
				}
			}
		}
		[TestMethod]
		public void RemoveItems()
		{
			using (var db = new TipographiesDataContext(ConnectionString))
			{
				int startItemsCount = db.Tipographies.Count();
				var item = db.Tipographies.FirstOrDefault();

				if (item != null)
				{
					db.Tipographies.Remove(item);
					db.SaveChanges();

					var removedItem = db.Tipographies.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Tipographies.Count());
				}
			}
		}
	}
}