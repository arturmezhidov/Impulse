using System;
using System.Collections.Generic;
using System.Linq;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public abstract class DataManager<T> : IDataManager<T> where T : class, new()
	{
		private IUnitOfWork uow;
		private IRepository<T> repository;
		private bool disposed;

		public DataManager(IUnitOfWork uow)
		{
			this.uow = uow;
			this.repository = uow.GetRepository<T>();
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
			T result = repository.Delete(id);

			return result;
		}

		public IQueryable<T> GetAll()
		{
			IQueryable<T> result = repository.GetAll();

			return result;
		}

		public IEnumerable<T> Create(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}

			if (!items.Any())
			{
				return items;
			}

			IEnumerable<T> result = repository.AddRange(items);

			return result;
		}

		public IEnumerable<T> Update(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}

			if (!items.Any())
			{
				return items;
			}

			var newItems = items.Where(IsNewItem);
			var updateItems = items.Except(newItems);

			if (newItems.Any())
			{
				repository.AddRange(newItems);
			}

			if (updateItems.Any())
			{
				repository.UpdateRange(updateItems);
			}

			IEnumerable<T> result = repository.UpdateRange(items);

			return result;
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
		protected abstract bool IsNewItem(T item);
	}
}