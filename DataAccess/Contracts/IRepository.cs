using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Impulse.DataAccess.Contracts
{
	public interface IRepository<T> where T : class, new()
	{
		T Create(T item);
		T Update(T item);
		T Delete(int id);
		T GetById(int id);
		IQueryable<T> GetAll(bool tracking = false);
		IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool tracking = false);
	}
}