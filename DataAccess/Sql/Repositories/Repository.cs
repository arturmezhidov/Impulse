using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;

namespace Impulse.DataAccess.Sql.Repositories
{
	public class Repository<T> : IRepository<T> where T : class, new()
	{
		protected readonly DbContext Context;
		protected readonly DbSet<T> Items;

		public Repository(EntityDataContext context)
		{
			Context = context;
			Items = context.Set<T>();
		}

		public virtual T Add(T item)
		{
			Items.Add(item);
			Context.SaveChanges();
			return item;
		}
		public virtual T Update(T item)
		{
			Context.Entry(item).State = EntityState.Modified;
			Context.SaveChanges();
			return item;
		}
		public virtual T Delete(object id)
		{
			T item = GetById(id);
			if (item != null)
			{
				Items.Remove(item);
				Context.SaveChanges();
			}
			return item;
		}
		public virtual T GetById(object id)
		{
			T result = Items.Find(id);
			return result;
		}
		public virtual IEnumerable<T> AddRange(IEnumerable<T> items)
		{
			Context.Configuration.AutoDetectChangesEnabled = false;
			List<T> result = new List<T>();

			foreach (var item in items)
			{
				result.Add(Items.Add(item));
			}

			Context.Configuration.AutoDetectChangesEnabled = true;
			Context.SaveChanges();

			return result;
		}
		public virtual IEnumerable<T> UpdateRange(IEnumerable<T> items)
		{
			Context.Configuration.AutoDetectChangesEnabled = false;

			foreach (var item in items)
			{
				Context.Entry(item).State = EntityState.Modified;
			}

			Context.Configuration.AutoDetectChangesEnabled = true;
			Context.SaveChanges();

			return items;
		}
		public virtual IQueryable<T> GetAll()
		{
			IQueryable<T> items = (IQueryable<T>)Items.AsNoTracking();
			return items;
		}
		public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
		{
			IQueryable<T> result = Items.AsNoTracking().Where(predicate);
			return result;
		}
	}
}