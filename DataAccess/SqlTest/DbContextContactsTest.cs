using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.Common.Models.Contacts;
using System.Collections.Generic;
using Impulse.DataAccess.Contracts;
using Impulse.DataAccess.Sql.Repositories;

namespace SqlTest
{
	[TestClass]
	public class DbContextContactsTest
	{
		public const string ConnectionString = "DbContextTestConnectionString";
		public const int AddressesCount = 100;
		public const int EmailsCount = 100;
		public const int PhonesCount = 500;
		public const int SocialsCount = 500;
		public const string UpdateKey = " - updated";

		[TestMethod]
		public void AddAddresses()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.Addresses.Count();

				for (int i = 1; i <= AddressesCount; i++)
				{
					db.Addresses.Add(new Address
					{
						Country = "country" + i,
						Region = "region" + i,
						City = "city" + i,
						Street = "street" + i,
						House = "house" + i,
						Latitube = i,
						Longitube = i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(AddressesCount, db.Addresses.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddEmails()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.Emails.Count();

				for (int i = 1; i <= EmailsCount; i++)
				{
					db.Emails.Add(new Email
					{
						Address = "address" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(EmailsCount, db.Emails.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddPhones()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.Phones.Count();

				for (int i = 1; i <= PhonesCount; i++)
				{
					db.Phones.Add(new Phone
					{
						Operator = "operator" + i,
						Number = "nimber" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(PhonesCount, db.Phones.Count() - startItemsCount);
			}
		}
		[TestMethod]
		public void AddSocials()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.Socials.Count();

				for (int i = 1; i <= SocialsCount; i++)
				{
					db.Socials.Add(new Social
					{
						Name = "name" + i,
						Url = "url" + i
					});
				}

				db.SaveChanges();

				Assert.AreEqual(SocialsCount, db.Socials.Count() - startItemsCount);
			}
		}

		[TestMethod]
		public void UpdateAddresses()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				foreach (var item in db.Addresses)
				{
					item.Country = item.Country + UpdateKey;
					item.Region = item.Region + UpdateKey;
					item.City = item.City + UpdateKey;
					item.Street = item.Street + UpdateKey;
					item.House = item.House + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.Addresses)
				{
					Assert.IsTrue(item.Country.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Region.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.City.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Street.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.House.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
				}
			}
		}
		[TestMethod]
		public void UpdateEmails()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				foreach (var item in db.Emails)
				{
					item.Address = item.Address + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.Emails)
				{
					Assert.IsTrue(item.Address.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
				}
			}
		}
		[TestMethod]
		public void UpdatePhones()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				foreach (var item in db.Phones)
				{
					item.Operator = item.Operator + UpdateKey;
					item.Number = item.Number + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.Phones)
				{
					Assert.IsTrue(item.Operator.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Number.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
				}
			}
		}
		[TestMethod]
		public void UpdateSocials()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				foreach (var item in db.Socials)
				{
					item.Name = item.Name + UpdateKey;
					item.Url = item.Url + UpdateKey;

					db.Entry(item).State = EntityState.Modified;
				}

				db.SaveChanges();

				foreach (var item in db.Socials)
				{
					Assert.IsTrue(item.Name.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
					Assert.IsTrue(item.Url.EndsWith(UpdateKey), "item.Name.EndsWith(UpdateKey)");
				}
			}
		}
 
		[TestMethod]
		public void RemoveAddresses()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.Addresses.Count();
				var item = db.Addresses.FirstOrDefault();

				if (item != null)
				{
					db.Addresses.Remove(item);
					db.SaveChanges();

					var removedItem = db.Addresses.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Addresses.Count());
				}
			}
		}
		[TestMethod]
		public void RemoveEmails()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.Emails.Count();
				var item = db.Emails.FirstOrDefault();

				if (item != null)
				{
					db.Emails.Remove(item);
					db.SaveChanges();

					var removedItem = db.Emails.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Emails.Count());
				}
			}
		}
		[TestMethod]
		public void RemovePhones()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.Phones.Count();
				var item = db.Phones.FirstOrDefault();

				if (item != null)
				{
					db.Phones.Remove(item);
					db.SaveChanges();

					var removedItem = db.Phones.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Phones.Count());
				}
			}
		}
		[TestMethod]
		public void RemoveSocials()
		{
			using (var db = new EntityDataContext(ConnectionString))
			{
				int startItemsCount = db.Socials.Count();
				var item = db.Socials.FirstOrDefault();

				if (item != null)
				{
					db.Socials.Remove(item);
					db.SaveChanges();

					var removedItem = db.Socials.FirstOrDefault(c => c.Id == item.Id);
					Assert.IsNull(removedItem, "removedItem != null");
					Assert.IsFalse(startItemsCount == db.Socials.Count());
				}
			}
		}
	}
}