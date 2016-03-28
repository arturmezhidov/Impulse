using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Impulse.DataAccess.Contracts;

namespace Impulse.DataAccess.Sql.Repositories
{
	public class BaseRepository<T> : IRepository<T> where T : class, new()
	{
		protected readonly DbContext Context;
		protected readonly DbSet<T> Items;

		public BaseRepository(DbContext context)
		{
			Context = context;
			Items = context.Set<T>();
		}

		public virtual T Create(T item)
		{
			Items.Add(item);
			return item;
		}
		public virtual T Update(T item)
		{
			Context.Entry(item).State = EntityState.Modified;
			return item;
		}
		public virtual T Delete(int id)
		{
			T item = GetById(id);
			if (item != null)
			{
				Items.Remove(item);
			}
			return item;
		}
		public virtual T GetById(int id)
		{
			T result = Items.Find(id);
			return result;
		}
		public IQueryable<T> GetAll(bool tracking = false)
		{
			IQueryable<T> queryable = tracking
				? (IQueryable<T>)Items
				: (IQueryable<T>)Items.AsNoTracking();
			return queryable;
		}
		public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool tracking = false)
		{
			IQueryable<T> result = tracking
				? Items.Where(predicate)
				: Items.AsNoTracking().Where(predicate);
			return result;
		}
	}
}