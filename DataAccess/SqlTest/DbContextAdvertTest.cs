﻿using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.Common.Models.Advertisements;
using Impulse.DataAccess.Sql.Repositories;
using Type = Impulse.Common.Models.Advertisements.Type;


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
			using (var db = new AdvertisementsDataContext(ConnectionString))
			{
				int startItemsCount = db.Types.Count();

				for (int i = 1; i <= CategoriesCount; i++)
				{
					db.Types.Add(new Type
					{
						Name = "name" + i,
						Description = "description" + i,
						Icon = "icon" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(CategoriesCount, db.Types.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddMaterials()
		{
			using (var db = new AdvertisementsDataContext(ConnectionString))
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
		public void AddAdverts()
		{
			using (var db = new AdvertisementsDataContext(ConnectionString))
			{
				int startItemsCount = db.Adverts.Count();
				var categories = db.Types.ToArray();
				var materials = db.Materials.ToArray();
				var addedCategories = new List<Type>();
				var addedMaterials = new List<Material>();
				var addedAdverts = new List<Advert>();

				for (int i = 1; i <= AdvertsCount; i++)
				{
					var Type = categories[i % (categories.Length - 1)];
					var material = materials[i % (materials.Length - 1)];
					var advert = new Advert
					{
						Name = "name" + i,
						Description = "description" + i,
						Image = "image" + i,
						Number = "number" + i,
						Type = Type,
						Material = material
					};

					db.Adverts.Add(advert);
					db.SaveChanges();

					addedCategories.Add(Type);
					addedMaterials.Add(material);
					addedAdverts.Add(advert);
				}

				Assert.AreEqual(AdvertsCount, db.Adverts.Count() - startItemsCount);

				for (int i = 0; i < AdvertsCount; i++)
				{
					var addedAdvert = addedAdverts[i];
					var advert = db.Adverts.FirstOrDefault(a => a.Id == addedAdvert.Id);
					Assert.IsNotNull(advert, "advert = null");
					Assert.IsNotNull(advert.Type, "advert.Type = null");
					Assert.IsNotNull(advert.Material, "advert.Material = null");

					var Type = db.Types.FirstOrDefault(c => c.Id == addedAdvert.Type.Id);
					Assert.IsNotNull(Type, "Type = null");

					var material = db.Materials.FirstOrDefault(m => m.Id == addedAdvert.Material.Id);
					Assert.IsNotNull(material, "material = null");
				}
			}
		}

		[TestMethod]
		public void UpdateCategories()
		{
			using (var db = new AdvertisementsDataContext(ConnectionString))
			{
				foreach (var item in db.Types)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Icon = item.Icon + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.Types)
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
			using (var db = new AdvertisementsDataContext(ConnectionString))
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
		public void UpdateAdverts()
		{
				using (var db = new AdvertisementsDataContext(ConnectionString))
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
						Assert.IsTrue(item.Image.EndsWith(UpdateKey), "item.Image.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Number.EndsWith(UpdateKey), "item.Number.EndsWith(UpdateKey)");
					}

					var random = new Random();
					var categories = db.Types.ToArray();
					var materials = db.Materials.ToArray();
					var adverts = db.Adverts.ToArray();

					for (int i = 0; i < adverts.Length; i++)
					{
						var TypeIndex = random.Next(0, categories.Length - 1);
						var materialIndex = random.Next(0, materials.Length - 1);

						var Type = categories[TypeIndex];
						var material = materials[materialIndex];
						var advert = adverts[i];

						advert.Type = Type;
						advert.Material = material;

						db.Entry(advert).State = EntityState.Modified;
						db.SaveChanges();

						var advertModify = db.Adverts.FirstOrDefault(a => a.Id == advert.Id);
						Assert.IsNotNull(advertModify, "advertModify = null");
						Assert.IsNotNull(advertModify.Type, "advertModify.Type = null");
						Assert.IsNotNull(advertModify.Material, "advertModify.Material = null");
						Assert.AreEqual(advert.Type.Id, advertModify.Type.Id, "advert.Type.Id, advertModify.Type.Id");
						Assert.AreEqual(advert.Material.Id, advertModify.Material.Id, "advert.Material.Id, advertModify.Material.Id");
					}
				}
		}

		[TestMethod]
		public void RemoveCategories()
		{
			using (var db = new AdvertisementsDataContext(ConnectionString))
			{
				int startItemsCount = db.Types.Count();
				var item = db.Types.FirstOrDefault();

				if (item != null)
				{
					db.Types.Remove(item);
					db.SaveChanges();

					var removedItem = db.Types.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Types.Count());
				}
			}
		}
		[TestMethod]
		public void RemoveMaterials()
		{
			using (var db = new AdvertisementsDataContext(ConnectionString))
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
		public void RemoveAdverts()
		{
			using (var db = new AdvertisementsDataContext(ConnectionString))
			{
				int startItemsCount = db.Adverts.Count();
				var item = db.Adverts.FirstOrDefault();

				if (item != null)
				{
					db.Adverts.Remove(item);
					db.SaveChanges();

					var removedItem = db.Adverts.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Adverts.Count());
				}
			}
		}
	}
}