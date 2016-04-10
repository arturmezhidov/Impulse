using System.Collections.Generic;
using System.Linq;
using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using Impulse.BusinessLogic.Components.Advertisements;
using Impulse.Common.Models.Advertisements;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentsTest
{
	[TestClass]
	public class DataManagerTestByAdvertsTypes
	{
		const string ConnectionString = "BusinessComponentsTestConnectionString";
		const int TypesCount = 100;

		[TestMethod]
		public void Create()
		{
			using (ITypeManager manager = new TypeManager(new AdvertisementsUnitOfWork(ConnectionString)))
			{
				for (int i = 1; i <= TypesCount; i++)
				{
					var createdItem = manager.Create(new Type
					{
						Name = "name" + i,
						Description = "description" + i,
						Icon = "icon" + i
					});

					Assert.IsNotNull(createdItem, "createdItem == null");
					Assert.IsTrue(createdItem.Id > 0, "createdItem.Id = " + createdItem.Id);
				}
			}
		}

		[TestMethod]
		public void Update()
		{
			using (ITypeManager manager = new TypeManager(new AdvertisementsUnitOfWork(ConnectionString)))
			{
				var items = manager.GetAll().ToList();
				var updateKey = System.DateTime.Now.Ticks.ToString();

				foreach (var item in items)
				{
					item.Name = item.Name + updateKey;
					item.Description = item.Description + updateKey;
					item.Icon = item.Icon + updateKey;

					manager.Update(item);
				}

				foreach (var item in manager.GetAll())
				{
					Assert.IsTrue(item.Name.EndsWith(updateKey), "item.Name.EndsWith(updateKey)");
					Assert.IsTrue(item.Description.EndsWith(updateKey), "item.Description.EndsWith(updateKey)");
					Assert.IsTrue(item.Icon.EndsWith(updateKey), "item.Icon.EndsWith(updateKey)");
				}
			}
		}

		[TestMethod]
		public void Delete()
		{
			using (ITypeManager manager = new TypeManager(new AdvertisementsUnitOfWork(ConnectionString)))
			{
				int startItemsCount = manager.GetAll().Count();
				var item = manager.GetAll().FirstOrDefault();

				if (item != null)
				{
					manager.Delete(item.Id);

					var removedItem = manager.GetAll().FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == manager.GetAll().Count());
				}
			}
		}

		[TestMethod]
		public void CreateAll()
		{
			using (ITypeManager manager = new TypeManager(new AdvertisementsUnitOfWork(ConnectionString)))
			{
				List<Type> items = new List<Type>();

				for (int i = 1; i <= TypesCount; i++)
				{
					items.Add(new Type
					{
						Name = "name" + i,
						Description = "description" + i,
						Icon = "icon" + i
					});
				}

				int beforeCount = manager.GetAll().Count();

				manager.Create(items);

				int afterCount = manager.GetAll().Count();

				Assert.AreEqual(beforeCount, afterCount - items.Count, "beforeCount, afterCount - items.Count");
			}
		}

		[TestMethod]
		public void UpdateAll()
		{
			using (ITypeManager manager = new TypeManager(new AdvertisementsUnitOfWork(ConnectionString)))
			{
				var updateKey = System.DateTime.Now.Ticks.ToString();
				var newKey = "qwertyuiop!@#$%^&*()";
				var existsItems = manager.GetAll().ToList();
				var newItems = new List<Type>();
				var allItems = new List<Type>();

				foreach (var item in existsItems)
				{
					item.Name = item.Name + updateKey;
					item.Description = item.Description + updateKey;
					item.Icon = item.Icon + updateKey;
				}

				for (int i = 1; i <= TypesCount; i++)
				{
					newItems.Add(new Type
					{
						Name = "name" + i + newKey,
						Description = "description" + i + newKey,
						Icon = "icon" + i + newKey
					});
				}

				allItems.AddRange(existsItems);
				allItems.AddRange(newItems);

				manager.Update(allItems);

				foreach (var item in manager.GetAll())
				{
					Assert.IsTrue(item.Name.EndsWith(updateKey) || item.Name.EndsWith(newKey), "item.Name.EndsWith(updateKey)");
					Assert.IsTrue(item.Description.EndsWith(updateKey) || item.Description.EndsWith(newKey), "item.Description.EndsWith(updateKey)");
					Assert.IsTrue(item.Icon.EndsWith(updateKey) || item.Icon.EndsWith(newKey), "item.Icon.EndsWith(updateKey)");
				}

				Assert.AreEqual(allItems.Count, manager.GetAll().Count(), "allItems.Count, manager.GetAll().Count()");
			}
		}
	}
}