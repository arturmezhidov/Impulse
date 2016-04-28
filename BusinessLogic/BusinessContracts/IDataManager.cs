using System.Linq;
using System.Collections.Generic;

namespace Impulse.BusinessLogic.BusinessContracts
{
	public interface IDataManager<T> : IBaseManager where T : class, new()
	{
		T Create(T item);
		T GetById(int id);
		T Update(T item);
		T Delete(int id);
		IQueryable<T> GetAll();
		IEnumerable<T> Create(IEnumerable<T> items);
		IEnumerable<T> Update(IEnumerable<T> items);
	}
}