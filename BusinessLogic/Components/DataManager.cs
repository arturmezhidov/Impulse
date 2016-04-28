using System;
using System.Collections.Generic;
using System.Linq;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public abstract class DataManager<T> : IDataManager<T> where T : BaseItem, new()
	{
		private readonly IUnitOfWork uow;
		private readonly IRepository<T> repository;
		private bool disposed;

		protected DataManager(IUnitOfWork uow)
		{
			this.uow = uow;
			repository = uow.GetRepository<T>();
		}

		public virtual T Create(T newItem)
		{
			if (newItem == null)
			{
				throw new ArgumentNullException("newItem");
			}

			T result = repository.Add(newItem);

			return result;
		}

		public virtual T GetById(int id)
		{
			T result = repository.GetById(id);

			return result;
		}

		public virtual T Update(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			item = repository.Update(item);

			return item;
		}

		public virtual T Delete(int id)
		{
			T item = repository.GetById(id);

			if (item != null)
			{
				item.IsDeleted = true;

				item = repository.Update(item);
			}

			return item;
		}

		public virtual IQueryable<T> GetAll()
		{
			IQueryable<T> result = repository
				.GetAll()
				.Where(i => !i.IsDeleted);

			return result;
		}

		public virtual IEnumerable<T> Create(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}

			var arrItems = items.ToArray();

			if (!arrItems.Any())
			{
				return arrItems;
			}

			IEnumerable<T> result = repository.AddRange(arrItems);

			return result;
		}

		public virtual IEnumerable<T> Update(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}

			var arrItems = (items as List<T>) ?? items.ToList();

			if (!arrItems.Any())
			{
				return arrItems;
			}

			var newItems = arrItems.Where(IsNewItem).ToList();
			var updateItems = arrItems.Except(newItems).ToList();

			if (newItems.Any())
			{
				repository.AddRange(newItems);
			}

			if (updateItems.Any())
			{
				repository.UpdateRange(updateItems);
			}

			return newItems.Concat(updateItems);
		}

		protected virtual bool IsNewItem(T item)
		{
			return item.Id <= 0;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					uow.Dispose();
				}
				disposed = true;
			}
		}
	}
}