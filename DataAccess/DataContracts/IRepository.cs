using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Impulse.DataAccess.DataContracts
{
	public interface IRepository<T> where T : class, new()
	{
		int Count { get; }
		T Add(T item);
		T Update(T item);
		T Delete(int id);
		T GetById(int id);
		IEnumerable<T> AddRange(IEnumerable<T> items);
		IEnumerable<T> UpdateRange(IEnumerable<T> items);
		IQueryable<T> GetAll(bool tracking = false);
		IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool tracking = false);
	}
}