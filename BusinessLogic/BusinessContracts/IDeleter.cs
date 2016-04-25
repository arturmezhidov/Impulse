using System;
using Impulse.Common.Models;

namespace Impulse.BusinessLogic.BusinessContracts
{
	public interface IDeleter<in T> where T : IDeletable
	{
		Func<T, bool> Check(T item);
		void Delete(T item);
		void Undelete(T item);
	}
}
