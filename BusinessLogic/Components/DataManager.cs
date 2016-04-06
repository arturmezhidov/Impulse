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

		public T GetById(int id)
		{
			T result = repository.GetById(id);

			return result;
		}

		public T Update(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			if (Contains(item))
			{
				item = repository.Update(item);
			}
			else
			{
				item = repository.Add(item);
			}

			return item;
		}

		public T Delete(int id)
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

			IEnumerable<T> result = repository.AddRange(items);

			return result;
		}

		public IEnumerable<T> Update(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}

			var existItems = items.Where(Contains);
			var newItems = items.Except(existItems);
			var result = new List<T>();

			if (existItems.Any())
			{
				result.AddRange(repository.UpdateRange(existItems));
			}

			if (newItems.Any())
			{
				result.AddRange(repository.AddRange(newItems));
			}

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

		protected abstract bool Contains(T item);
	}
}