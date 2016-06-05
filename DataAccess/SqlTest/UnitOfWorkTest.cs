using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;

namespace SqlTest
{
	[TestClass]
	public class UnitOfWorkTest {
		public const string ConnectionString = "DALTestConnectionString";
		public const int AdvertsCategoriesCount = 100;
		public const int AdvertsCount = 500;
		public const string UpdateKey = " - updated";
		[TestMethod]
		public void AddCategories()
		{
			using (IUnitOfWork uow = new UnitOfWork(ConnectionString))
			{
				uow.AdvertsCategories.Add(new AdvertsCategory()
				{
					Name = "Name",
					Description = "Description",
					Icon = "Icon",
					SortingNumber = 1
				});

				int startItemsCount = uow.AdvertsCategories.GetAll().Count();
				List<AdvertsCategory> items = new List<AdvertsCategory>();

				for (int i = 1; i <= AdvertsCategoriesCount; i++)
				{
					items.Add(new AdvertsCategory
					{
						Name = "name" + i,
						Description = "description" + i,
						Icon = "icon" + i
					});
				}

				uow.AdvertsCategories.AddRange(items);

				Assert.AreEqual(AdvertsCategoriesCount, uow.AdvertsCategories.GetAll().Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddAdverts()
		{
			using (IUnitOfWork uow = new UnitOfWork(ConnectionString))
			{
				var startItemsCount = uow.Adverts.GetAll().Count();
				var categories = uow.AdvertsCategories.GetAll().ToArray();
				var addedCategories = new List<AdvertsCategory>();
				var addedAdverts = new List<Advert>();

				for (int i = 1; i <= AdvertsCount; i++)
				{
					var category = categories[i % (categories.Length - 1)];
					var advert = new Advert
					{
						Name = "name" + i,
						Description = "description" + i,
						Image = "image" + i,
						Number = "number" + i,
						Category = category
					};

					addedCategories.Add(category);
					addedAdverts.Add(advert);
				}

				uow.Adverts.AddRange(addedAdverts); 

				uow.Save();

				Assert.AreEqual(AdvertsCount, uow.Adverts.GetAll().Count() - startItemsCount);

				for (int i = 0; i < AdvertsCount; i++)
				{
					var addedAdvert = addedAdverts[i];
					var advert = uow.Adverts.GetAll().FirstOrDefault(a => a.Id == addedAdvert.Id);
					Assert.IsNotNull(advert, "advert = null");
					Assert.IsNotNull(advert.Category, "advert.Category = null");

					var category = uow.AdvertsCategories.GetAll().FirstOrDefault(c => c.Id == addedAdvert.Category.Id);
					Assert.IsNotNull(category, "category = null");
				}
			}
		}
		[TestMethod]
		public void UpdateCategories()
		{
			using (IUnitOfWork uow = new UnitOfWork(ConnectionString))
			{
				var items = uow.AdvertsCategories.GetAll().ToList();
				foreach (var item in items)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Icon = item.Icon + UpdateKey;
				}

				uow.AdvertsCategories.UpdateRange(items);

				foreach (var item in uow.AdvertsCategories.GetAll())
				{
					Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Icon.EndsWith(UpdateKey), "item.Icon.EndsWith(UpdateKey)");
				}
			}
		}
		[TestMethod]
		public void UpdateAdverts()
		{
				using (IUnitOfWork uow = new UnitOfWork(ConnectionString))
				{
					var items = uow.Adverts.GetAll().ToList();
					foreach (var item in items)
					{
						item.Name = item.Name + UpdateKey;
						item.Description = item.Description + UpdateKey;
						item.Image = item.Image + UpdateKey;
						item.Number = item.Number + UpdateKey;
					}

					uow.Adverts.UpdateRange(items);

					foreach (var item in uow.Adverts.GetAll())
					{
						Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Image.EndsWith(UpdateKey), "item.Image.EndsWith(UpdateKey)");
						Assert.IsTrue(item.Number.EndsWith(UpdateKey), "item.Number.EndsWith(UpdateKey)");
					}
				}
				using (IUnitOfWork uow = new UnitOfWork(ConnectionString))
				{
					var random = new Random();
					var categories = uow.AdvertsCategories.GetAll().ToArray();
					var adverts = uow.Adverts.GetAll().ToArray();

					for (int i = 0; i < adverts.Length; i++)
					{
						var categoryIndex = random.Next(0, categories.Length - 1);
						var category = categories[categoryIndex];
						var advert = uow.Adverts.GetById(adverts[i].Id);

						advert.Category = uow.AdvertsCategories.GetById(category.Id);

						uow.Adverts.Update(advert);

						var advertModify = uow.Adverts.GetAll().FirstOrDefault(a => a.Id == advert.Id);
						Assert.IsNotNull(advertModify, "advertModify = null");
						Assert.IsNotNull(advertModify.Category, "advertModify.Category = null");
						Assert.AreEqual(advert.Category.Id, advertModify.Category.Id, "advert.Category.Id, advertModify.Category.Id");
					}
				}
		}
		[TestMethod]
		public void RemoveCategories()
		{
			using (IUnitOfWork uow = new UnitOfWork(ConnectionString))
			{
				int startItemsCount = uow.AdvertsCategories.GetAll().Count();
				var item = uow.AdvertsCategories.GetAll().FirstOrDefault();

				if (item != null)
				{
					uow.AdvertsCategories.Delete(item.Id);

					var removedItem = uow.AdvertsCategories.GetAll().FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == uow.AdvertsCategories.GetAll().Count());
				}
			}
		}
		[TestMethod]
		public void RemoveAdverts()
		{
			using (IUnitOfWork uow = new UnitOfWork(ConnectionString))
			{
				int startItemsCount = uow.Adverts.GetAll().Count();
				var item = uow.Adverts.GetAll().FirstOrDefault();

				if (item != null)
				{
					uow.Adverts.Delete(item.Id);

					var removedItem = uow.Adverts.GetAll().FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == uow.Adverts.GetAll().Count());
				}
			}
		}
	}
}
