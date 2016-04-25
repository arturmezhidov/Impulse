using System;
using System.Collections.Generic;
using Impulse.Common.Models;

namespace Impulse.BusinessLogic.BusinessContracts
{
	public interface ISorter<in T> where T : ISortable
	{
		bool Comparator(T first, T second);
		Func<T, bool> Compare(T item);
		void Sort(IEnumerable<T> items);
	}
}
