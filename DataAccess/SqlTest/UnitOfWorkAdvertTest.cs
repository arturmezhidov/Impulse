using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Impulse.Common.Models.Advertisements;
using Impulse.DataAccess.Sql.Repositories;
using Type = Impulse.Common.Models.Advertisements.Type;


namespace SqlTest
{
	[TestClass]
	public class UnitOfWorkAdvertTest
	{
		public const string ConnectionString = "DbContextTestConnectionString";
		public const int CategoriesCount = 100;
		public const int MaterialsCount = 100;
		public const int AdvertsCount = 500;
		public const string UpdateKey = " - updated";

		[TestMethod]
		public void AddCategories()
		{
			using (var db = new AdvertisementsUnitOfWork(ConnectionString))
			{
				int startItemsCount = db.Types.Count;
				List<Type> items = new List<Type>();

				for (int i = 1; i <= CategoriesCount; i++)
				{
					items.Add(new Type
					{
						Name = "name" + i,
						Description = "description" + i,
						Icon = "icon" + i
					});
				}

				db.Types.AddRange(items);

				Assert.AreEqual(CategoriesCount, db.Types.Count - startItemsCount);
			}
		}
		[TestMethod]
		public void AddMaterials()
		{
			using (var db = new AdvertisementsUnitOfWork(ConnectionString))
			{
				int startItemsCount = db.Materials.Count;
				List<Material> items = new List<Material>();

				for (int i = 1; i <= MaterialsCount; i++)
				{
					items.Add(new Material
					{
						Name = "name" + i
					});
				}

				db.Materials.AddRange(items);

				Assert.AreEqual(MaterialsCount, db.Materials.Count - startItemsCount);
			}
		}
		[TestMethod]
		public void AddAdverts()
		{
			using (var db = new AdvertisementsUnitOfWork(ConnectionString))
			{
				int startItemsCount = db.Adverts.Count;
				var categories = db.Types.GetAll().ToArray();
				var materials = db.Materials.GetAll().ToArray();
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

					addedCategories.Add(Type);
					addedMaterials.Add(material);
					addedAdverts.Add(advert);
				}

				db.Adverts.AddRange(addedAdverts); 

				Assert.AreEqual(AdvertsCount, db.Adverts.Count - startItemsCount);

				for (int i = 0; i < AdvertsCount; i++)
				{
					var addedAdvert = addedAdverts[i];
					var advert = db.Adverts.GetAll().FirstOrDefault(a => a.Id == addedAdvert.Id);
					Assert.IsNotNull(advert, "advert = null");
					Assert.IsNotNull(advert.Type, "advert.Type = null");
					Assert.IsNotNull(advert.Material, "advert.Material = null");

					var Type = db.Types.GetAll().FirstOrDefault(c => c.Id == addedAdvert.Type.Id);
					Assert.IsNotNull(Type, "Type = null");

					var material = db.Materials.GetAll().FirstOrDefault(m => m.Id == addedAdvert.Material.Id);
					Assert.IsNotNull(material, "material = null");
				}
			}
		}

		[TestMethod]
		public void UpdateCategories()
		{
			using (var db = new AdvertisementsUnitOfWork(ConnectionString))
			{
				var items = db.Types.GetAll().ToList();
				foreach (var item in items)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Icon = item.Icon + UpdateKey;
				}

				db.Types.UpdateRange(items);

				foreach (var item in db.Types.GetAll())
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
			using (var db = new AdvertisementsUnitOfWork(ConnectionString))
			{
				var items = db.Materials.GetAll().ToList();
				foreach (var item in items)
				{
					item.Name = item.Name + UpdateKey;
				}

				db.Materials.UpdateRange(items);

				foreach (var item in db.Materials.GetAll())
				{
					Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
				}
			}
		}
		[TestMethod]
		public void UpdateAdverts()
		{
				using (var db = new AdvertisementsUnitOfWork(ConnectionString))
				{
					var items = db.Adverts.GetAll().ToList();
					foreach (var item in items)
					{
						item.Name = item.Name + UpdateKey;
						item.Description = item.Description + UpdateKey;
						item.Image = item.Image + UpdateKey;
						item.Number = item.Number + UpdateKey;
					}

					db.Adverts.UpdateRange(items);

					foreach (var item in db.Adverts.GetAll())
					{
						Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Image.EndsWith(UpdateKey), "item.Image.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Number.EndsWith(UpdateKey), "item.Number.EndsWith(UpdateKey)");
					}
				}
				using (var db = new AdvertisementsUnitOfWork(ConnectionString))
				{
					var random = new Random();
					var categories = db.Types.GetAll().ToArray();
					var materials = db.Materials.GetAll().ToArray();
					var adverts = db.Adverts.GetAll().ToArray();

					for (int i = 0; i < adverts.Length; i++)
					{
						var TypeIndex = random.Next(0, categories.Length - 1);
						var materialIndex = random.Next(0, materials.Length - 1);

						var type = categories[TypeIndex];
						var material = materials[materialIndex];
						var advert = db.Adverts.GetById(adverts[i].Id);

						advert.Type = db.Types.GetById(type.Id);
						advert.Material = db.Materials.GetById(material.Id);

						db.Adverts.Update(advert);

						var advertModify = db.Adverts.GetAll().FirstOrDefault(a => a.Id == advert.Id);
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
			using (var db = new AdvertisementsUnitOfWork(ConnectionString))
			{
				int startItemsCount = db.Types.Count;
				var item = db.Types.GetAll().FirstOrDefault();

				if (item != null)
				{
					db.Types.Delete(item.Id);

					var removedItem = db.Types.GetAll().FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Types.Count);
				}
			}
		}
		[TestMethod]
		public void RemoveMaterials()
		{
			using (var db = new AdvertisementsUnitOfWork(ConnectionString))
			{
				int startItemsCount = db.Materials.Count;
				var item = db.Materials.GetAll().FirstOrDefault();

				if (item != null)
				{
					db.Materials.Delete(item.Id);

					var removedItem = db.Materials.GetAll().FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Materials.Count);
				}
			}
		}
		[TestMethod]
		public void RemoveAdverts()
		{
			using (var db = new AdvertisementsUnitOfWork(ConnectionString))
			{
				int startItemsCount = db.Adverts.Count;
				var item = db.Adverts.GetAll().FirstOrDefault();

				if (item != null)
				{
					db.Adverts.Delete(item.Id); 

					var removedItem = db.Adverts.GetAll().FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Adverts.Count);
				}
			}
		}
	}
}