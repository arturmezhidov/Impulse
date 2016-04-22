using System.Linq;

namespace Impulse.Common.Models.Application
{
	public class Page<T>
	{
		public IQueryable<T> Items { get; set; }
		public bool HasNextPage { get; set; }
		public bool HasPreviousPage { get; set; }
		public bool IsFirstPage { get; set; }
		public bool IsLastPage { get; set; }
		public int PageCount { get; set; }
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int TotalCount { get; set; }
	}
}