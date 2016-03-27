using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.Common.Models.Advertisements;
using System.Collections.Generic;

namespace SqlTest
{
	[TestClass]
	public class DbContextAdvertTest
	{
		public const string ConnectionString = "DbContextTestConnectionString";
		public const int CategoriesCount = 100;
		public const int MaterialsCount = 100;
		public const int AdvertsCount = 500;
		public const string UpdateKey = " - updated";

		[TestMethod]
		public void AddCategories()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.AdvertsCategories.Count();

				for (int i = 1; i <= CategoriesCount; i++)
				{
					db.AdvertsCategories.Add(new Category
					{
						Name = "name" + i,
						Description = "description" + i,
						Icon = "icon" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(CategoriesCount, db.AdvertsCategories.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddMaterials()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.AdvertsMaterials.Count();

				for (int i = 1; i <= MaterialsCount; i++)
				{
					db.AdvertsMaterials.Add(new Material
					{
						Name = "name" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(MaterialsCount, db.AdvertsMaterials.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddAdverts()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.Adverts.Count();
				var categories = db.AdvertsCategories.ToArray();
				var materials = db.AdvertsMaterials.ToArray();
				var addedCategories = new List<Category>();
				var addedMaterials = new List<Material>();
				var addedAdverts = new List<Advert>();

				for (int i = 1; i <= AdvertsCount; i++)
				{
					var category = categories[i % (categories.Length - 1)];
					var material = materials[i % (materials.Length - 1)];
					var advert = new Advert
					{
						Name = "name" + i,
						Description = "description" + i,
						Image = "image" + i,
						Number = "number" + i,
						Category = category,
						Material = material
					};

					db.Adverts.Add(advert);
					db.SaveChanges();

					addedCategories.Add(category);
					addedMaterials.Add(material);
					addedAdverts.Add(advert);
				}

				Assert.AreEqual(AdvertsCount, db.Adverts.Count() - startItemsCount);

				for (int i = 0; i < AdvertsCount; i++)
				{
					var addedAdvert = addedAdverts[i];
					var advert = db.Adverts.FirstOrDefault(a => a.Id == addedAdvert.Id);
					Assert.IsNotNull(advert, "advert = null");
					Assert.IsNotNull(advert.Category, "advert.Category = null");
					Assert.IsNotNull(advert.Material, "advert.Material = null");

					var category = db.AdvertsCategories.FirstOrDefault(c => c.Id == addedAdvert.Category.Id);
					Assert.IsNotNull(category, "category = null");

					var material = db.AdvertsMaterials.FirstOrDefault(m => m.Id == addedAdvert.Material.Id);
					Assert.IsNotNull(material, "material = null");
				}
			}
		}

		[TestMethod]
		public void UpdateCategories()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				foreach (var item in db.AdvertsCategories)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Icon = item.Icon + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.AdvertsCategories)
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
			using (var db = new EntityDataContext(ConnectionString))
			{
				foreach (var item in db.AdvertsMaterials)
				{
					item.Name = item.Name + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.AdvertsMaterials)
				{
					Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
				}
			}
		}
		[TestMethod]
		public void UpdateAdverts()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				foreach (var item in db.Adverts)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Image = item.Image + UpdateKey;
					item.Number = item.Number + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.Adverts)
				{
					Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Image.EndsWith(UpdateKey),"item.Image.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Number.EndsWith(UpdateKey), "item.Number.EndsWith(UpdateKey)");
				}

				var random = new Random();
				var categories = db.AdvertsCategories.ToArray();
				var materials = db.AdvertsMaterials.ToArray();
				var adverts = db.Adverts.ToArray();

				for (int i = 0; i < adverts.Length; i++)
				{
					var categoryIndex = random.Next(0, categories.Length - 1);
					var materialIndex = random.Next(0, materials.Length - 1);

					var category = categories[categoryIndex];
					var material = materials[materialIndex];
					var advert = adverts[i];

					advert.Category = category;
					advert.Material = material;

					db.Entry(advert).State = EntityState.Modified;
					db.SaveChanges();

					var advertModify = db.Adverts.FirstOrDefault(a => a.Id == advert.Id);
					Assert.IsNotNull(advertModify, "advertModify = null");
					Assert.IsNotNull(advertModify.Category, "advertModify.Category = null");
					Assert.IsNotNull(advertModify.Material, "advertModify.Material = null");
					Assert.AreEqual(advert.Category.Id, advertModify.Category.Id, "advert.Category.Id, advertModify.Category.Id");
					Assert.AreEqual(advert.Material.Id, advertModify.Material.Id, "advert.Material.Id, advertModify.Material.Id");
				}
			}
		}

		[TestMethod]
		public void RemoveCategories()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.AdvertsCategories.Count();
				var item = db.AdvertsCategories.FirstOrDefault();

				if (item != null)
				{
					db.AdvertsCategories.Remove(item);
					db.SaveChanges();

					var removedItem = db.AdvertsCategories.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.AdvertsCategories.Count());
				}
			}
		}
		[TestMethod]
		public void RemoveMaterials()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.AdvertsMaterials.Count();
				var item = db.AdvertsMaterials.FirstOrDefault();

				if (item != null)
				{
					db.AdvertsMaterials.Remove(item);
					db.SaveChanges();

					var removedItem = db.AdvertsMaterials.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.AdvertsMaterials.Count());
				}
			}
		}
		[TestMethod]
		public void RemoveAdverts()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.Adverts.Count();
				var item = db.Adverts.FirstOrDefault();

				if (item != null)
				{
					db.Adverts.Remove(item);
					db.SaveChanges();

					var removedItem = db.Adverts.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.AdvertsCategories.Count());
				}
			}
		}
	}
}