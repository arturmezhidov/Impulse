using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.Common.Models.Stends;
using System.Collections.Generic;
using Impulse.DataAccess.Sql.Repositories;

namespace SqlTest
{
	[TestClass]
	public class UnitOfWorkStendsTest
	{
		public const string ConnectionString = "DbContextTestConnectionString";
		public const int CategoriesCount = 100;
		public const int MaterialsCount = 100;
		public const int StendsCount = 500;
		public const string UpdateKey = " - updated";

		[TestMethod]
		public void AddCategories()
		{
			using (var db = new StendsDataContext(ConnectionString))
			{
				int startItemsCount = db.Categories.Count();

				for (int i = 1; i <= CategoriesCount; i++)
				{
					db.Categories.Add(new Category
					{
						Name = "name" + i,
						Description = "description" + i,
						Icon = "icon" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(CategoriesCount, db.Categories.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddMaterials()
		{
			using (var db = new StendsDataContext(ConnectionString))
			{
				int startItemsCount = db.Materials.Count();

				for (int i = 1; i <= MaterialsCount; i++)
				{
					db.Materials.Add(new Material
					{
						Name = "name" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(MaterialsCount, db.Materials.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddStends()
		{
			using (var db = new StendsDataContext(ConnectionString))
			{
				int startItemsCount = db.Stends.Count();
				var categories = db.Categories.ToArray();
				var materials = db.Materials.ToArray();
				var addedCategories = new List<Category>();
				var addedMaterials = new List<Material>();
				var addedItems = new List<Stend>();

				for (int i = 1; i <= StendsCount; i++)
				{
					var category = categories[i % (categories.Length - 1)];
					var material = materials[i % (materials.Length - 1)];
					var advert = new Stend
					{
						Name = "name" + i,
						Description = "description" + i,
						Image = "image" + i,
						Number = "number" + i,
						Category = category,
						Material = material,
						Eyelets = i,
						IsBorder = (i % 2) == 0,
						Pockets = i
					};

					db.Stends.Add(advert);
					db.SaveChanges();

					addedCategories.Add(category);
					addedMaterials.Add(material);
					addedItems.Add(advert);
				}

				Assert.AreEqual(StendsCount, db.Stends.Count() - startItemsCount);

				for (int i = 0; i < StendsCount; i++)
				{
					var addedItem = addedItems[i];
					var item = db.Stends.FirstOrDefault(a => a.Id == addedItem.Id);
					Assert.IsNotNull(item, "item = null");
					Assert.IsNotNull(item.Category, "item.Category = null");
					Assert.IsNotNull(item.Material, "item.Material = null");

					var category = db.Categories.FirstOrDefault(c => c.Id == addedItem.Category.Id);
					Assert.IsNotNull(category, "category = null");

					var material = db.Materials.FirstOrDefault(m => m.Id == addedItem.Material.Id);
					Assert.IsNotNull(material, "material = null");
				}
			}
		}

		[TestMethod]
		public void UpdateCategories()
		{
			using (var db = new StendsDataContext(ConnectionString))
			{
				foreach (var item in db.Categories)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Icon = item.Icon + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.Categories)
				{
					Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Icon.EndsWith(UpdateKey), "item.Icon.EndsWith(UpdateKey)");
				}
			}
		}
		[TestMethod]
		public void UpdateMaterials()
		{
			using (var db = new StendsDataContext(ConnectionString))
			{
				foreach (var item in db.Materials)
				{
					item.Name = item.Name + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.Materials)
				{
					Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
				}
			}
		}
		[TestMethod]
		public void UpdateStends()
		{
				using (var db = new StendsDataContext(ConnectionString))
				{
					foreach (var item in db.Stends)
					{
						item.Name = item.Name + UpdateKey;
						item.Description = item.Description + UpdateKey;
						item.Image = item.Image + UpdateKey;
						item.Number = item.Number + UpdateKey;

						db.Entry(item).State = EntityState.Modified;
					}

					db.SaveChanges();

					foreach (var item in db.Stends)
					{
						Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Image.EndsWith(UpdateKey), "item.Image.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Number.EndsWith(UpdateKey), "item.Number.EndsWith(UpdateKey)");
					}

					var random = new Random();
					var categories = db.Categories.ToArray();
					var materials = db.Materials.ToArray();
					var Stends = db.Stends.ToArray();

					for (int i = 0; i < Stends.Length; i++)
					{
						var categoryIndex = random.Next(0, categories.Length - 1);
						var materialIndex = random.Next(0, materials.Length - 1);

						var category = categories[categoryIndex];
						var material = materials[materialIndex];
						var item = Stends[i];

						item.Category = category;
						item.Material = material;

						db.Entry(item).State = EntityState.Modified;
						db.SaveChanges();

						var itemModify = db.Stends.FirstOrDefault(a => a.Id == item.Id);
						Assert.IsNotNull(itemModify, "itemModify = null");
						Assert.IsNotNull(itemModify.Category, "itemModify.Category = null");
						Assert.IsNotNull(itemModify.Material, "itemModify.Material = null");
						Assert.AreEqual(item.Category.Id, itemModify.Category.Id, "item.Category.Id, itemModify.Category.Id");
						Assert.AreEqual(item.Material.Id, itemModify.Material.Id, "item.Material.Id, itemModify.Material.Id");
					}
				}
		}

		[TestMethod]
		public void RemoveCategories()
		{
			using (var db = new StendsDataContext(ConnectionString))
			{
				int startItemsCount = db.Categories.Count();
				var item = db.Categories.FirstOrDefault();

				if (item != null)
				{
					db.Categories.Remove(item);
					db.SaveChanges();

					var removedItem = db.Categories.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Categories.Count());
				}
			}
		}
		[TestMethod]
		public void RemoveMaterials()
		{
			using (var db = new StendsDataContext(ConnectionString))
			{
				int startItemsCount = db.Materials.Count();
				var item = db.Materials.FirstOrDefault();

				if (item != null)
				{
					db.Materials.Remove(item);
					db.SaveChanges();

					var removedItem = db.Materials.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Materials.Count());
				}
			}
		}
		[TestMethod]
		public void RemoveStends()
		{
			using (var db = new StendsDataContext(ConnectionString))
			{
				int startItemsCount = db.Stends.Count();
				var item = db.Stends.FirstOrDefault();

				if (item != null)
				{
					db.Stends.Remove(item);
					db.SaveChanges();

					var removedItem = db.Stends.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Stends.Count());
				}
			}
		}
	}
}