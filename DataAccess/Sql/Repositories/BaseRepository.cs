using Impulse.DataAccess.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.DataAccess.Sql.Repositories
{
	public class BaseRepository<T> : IRepository<T>, IQueryable<T>, IEnumerable<T>, IQueryable, IEnumerable where T : class
	{
		protected readonly DbContext Context;
		protected readonly DbSet<T> Items;

		public BaseRepository(DbContext context)
		{
			Context = context;
			Items = context.Set<T>();
		}

		#region Implementation of IRepository<T>

		public virtual T Create(T item)
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

		public virtual T Delete(int id)
		{
			T item = Items.Find(id);

			if (item != null)
			{
				Items.Remove(item);
				Context.SaveChanges();
			}

			return item;
		}

		public virtual T GetById(int id)
		{
			T result = Items.Find(id);
			return result;
		}

		public virtual IEnumerable<T> GetAll()
		{
			return Items;
		}

		public virtual IEnumerable<T> Find(Func<T, bool> predicate)
		{
			IEnumerable<T> result = Items.Where(predicate);
			return result;
		}

		#endregion

		#region Implementation of IEnumerator & IEnumerator<T>

		public IEnumerator GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return ((IEnumerable<T>)Items).GetEnumerator();
		}

		#endregion

		#region Implementation of IQueryable & IQueryable<T>

		public Type ElementType
		{
			get { throw new NotImplementedException(); }
		}

		public System.Linq.Expressions.Expression Expression
		{
			get { throw new NotImplementedException(); }
		}

		public IQueryProvider Provider
		{
			get { throw new NotImplementedException(); }
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		Type IQueryable.ElementType
		{
			get { throw new NotImplementedException(); }
		}

		System.Linq.Expressions.Expression IQueryable.Expression
		{
			get { throw new NotImplementedException(); }
		}

		IQueryProvider IQueryable.Provider
		{
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}