using System;
using System.Linq;
using System.Collections.Generic;

namespace Impulse.BusinessLogic.BusinessContracts
{
	public interface IDataService<T> : IDisposable where T : class, new()
	{
		T Create(T item);
		T GetById(object id);
		T Update(T item);
		T Delete(object id);
		IQueryable<T> GetAll();
		IEnumerable<T> Create(IEnumerable<T> items);
		IEnumerable<T> Update(IEnumerable<T> items);
	}
}