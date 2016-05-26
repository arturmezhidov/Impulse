using System.Collections.Generic;
using System.Linq;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.BusinessLogic.Components;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentsTest
{
	[TestClass]
	public class UnitOfWorkTest
	{
		public const string ConnectionString = "BLLTestConnectionString";
		public const int AdvertsCategoriesCount = 100;
		public const int AdvertsCount = 500;
		public const string UpdateKey = " - updated";

		[TestMethod]
		public void CreateCategories()
		{
			using (IAdvertsCategoryService service = new AdvertsCategoryService(new UnitOfWork(ConnectionString)))
			{
				service.Create(new AdvertsCategory()
				{
					Name = "Name",
					Description = "Description",
					Icon = "Icon",
					SortingNumber = 1
				});

				int startItemsCount = service.GetAll().Count();
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

				service.Create(items);

				Assert.AreEqual(AdvertsCategoriesCount, service.GetAll().Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void CreateAdverts()
		{
			var uow = new UnitOfWork(ConnectionString);

			using (AdvertService advertsService = new AdvertService(uow))
			using (IAdvertsCategoryService categoryService = new AdvertsCategoryService(uow))
			{
				var startItemsCount = advertsService.GetAll().Count();
				var categories = categoryService.GetAll().ToArray();
				var createedCategories = new List<AdvertsCategory>();
				var createedAdverts = new List<Advert>();

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

					createedCategories.Add(category);
					createedAdverts.Add(advert);
				}

				advertsService.Create(createedAdverts);

				Assert.AreEqual(AdvertsCount, advertsService.GetAll().Count() - startItemsCount);

				for (int i = 0; i < AdvertsCount; i++)
				{
					var createedAdvert = createedAdverts[i];
					var advert = advertsService.GetAll().FirstOrDefault(a => a.Id == createedAdvert.Id);
					Assert.IsNotNull(advert, "advert = null");
					Assert.IsNotNull(advert.Category, "advert.Category = null");

					var category = categoryService.GetAll().FirstOrDefault(c => c.Id == createedAdvert.Category.Id);
					Assert.IsNotNull(category, "category = null");
				}
			}
		}

		[TestMethod]
		public void UpdateCategories()
		{
			using (IAdvertsCategoryService service = new AdvertsCategoryService(new UnitOfWork(ConnectionString)))
			{
				var items = service.GetAll().ToList();
				foreach (var item in items)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Icon = item.Icon + UpdateKey;
				}

				service.Update(items);

				foreach (var item in service.GetAll())
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
			using (AdvertService advertsService = new AdvertService(new UnitOfWork(ConnectionString)))
			{
				var items = advertsService.GetAll().ToList();
				foreach (var item in items)
				{
					item.Name = item.Name + UpdateKey;
					item.Description = item.Description + UpdateKey;
					item.Image = item.Image + UpdateKey;
					item.Number = item.Number + UpdateKey;
				}

				advertsService.Update(items);

				foreach (var item in advertsService.GetAll())
				{
					Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Description.EndsWith(UpdateKey), "item.Description.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Image.EndsWith(UpdateKey), "item.Image.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Number.EndsWith(UpdateKey), "item.Number.EndsWith(UpdateKey)");
				}
			}
		}

		[TestMethod]
		public void RemoveCategories()
		{
			using (IAdvertsCategoryService service = new AdvertsCategoryService(new UnitOfWork(ConnectionString)))
			{
				int startItemsCount = service.GetAll().Count();
				var item = service.GetAll().FirstOrDefault();

				if (item != null)
				{
					service.Delete(item.Id);

					var removedItem = service.GetAll().FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == service.GetAll().Count());
				}
			}
		}
		[TestMethod]
		public void RemoveAdverts()
		{
			using (IAdvertService service = new AdvertService(new UnitOfWork(ConnectionString)))
			{
				int startItemsCount = service.GetAll().Count();
				var item = service.GetAll().FirstOrDefault();

				if (item != null)
				{
					service.Delete(item.Id);

					var removedItem = service.GetAll().FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == service.GetAll().Count());
				}
			}
		}
	}
}