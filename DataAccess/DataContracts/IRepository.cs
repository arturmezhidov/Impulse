using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Impulse.DataAccess.DataContracts
{
	public interface IRepository<T> where T : class, new()
	{
		T Add(T item);
		T Update(T item);
		T Delete(object id);
		T GetById(object id);
		IEnumerable<T> AddRange(IEnumerable<T> items);
		IEnumerable<T> UpdateRange(IEnumerable<T> items);
		IQueryable<T> GetAll();
		IQueryable<T> Find(Expression<Func<T, bool>> predicate);
	}
}