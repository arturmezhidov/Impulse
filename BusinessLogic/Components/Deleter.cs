using System;
using System.Linq.Expressions;
using Impulse.Common.Models;

namespace Impulse.BusinessLogic.Components
{
	public static class Deleter
	{
		public static Expression<Func<T, bool>> Filter<T>(T item) where T : IDeletable
		{
			return (i => !i.IsDeleted);
		}

		public static void Delete<T>(T item) where T : IDeletable
		{
			item.IsDeleted = true;
		}

		public static void Undelete<T>(T item) where T : IDeletable
		{
			item.IsDeleted = false;
		}
	}
}
