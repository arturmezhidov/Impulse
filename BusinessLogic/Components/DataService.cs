using System;
using System.Collections.Generic;
using System.Linq;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public abstract class DataService<T> : IDataService<T> where T : BaseEntity, new()
	{
		protected readonly IUnitOfWork UnitOfWork;
		protected readonly IRepository<T> Repository;
		private bool disposed;

		protected DataService(IUnitOfWork uow)
		{
			UnitOfWork = uow;
			Repository = uow.GetRepository<T>();
		}

		public virtual T Create(T newItem)
		{
			if (newItem == null)
			{
				throw new ArgumentNullException("newItem");
			}

			T result = Repository.Add(newItem);

			return result;
		}

		public virtual T GetById(int id)
		{
			T result = Repository.GetById(id);

			return result;
		}

		public virtual T Update(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			item = IsNewItem(item) 
				? Repository.Add(item) 
				: Repository.Update(item);

			return item;
		}

		public virtual T Delete(int id)
		{
			T item = Repository.GetById(id);

			if (item != null)
			{
				item.IsDeleted = true;

				item = Repository.Update(item);
			}

			return item;
		}

		public virtual IQueryable<T> GetAll()
		{
			IQueryable<T> result = Repository
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

			IEnumerable<T> result = Repository.AddRange(arrItems);

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
				Repository.AddRange(newItems);
			}

			if (updateItems.Any())
			{
				Repository.UpdateRange(updateItems);
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
					UnitOfWork.Dispose();
				}
				disposed = true;
			}
		}
	}
}