using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.PrintShops
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }

		public virtual ICollection<Tipography> Tipographies { get; set; }

		public Category()
		{
			Tipographies = new HashSet<Tipography>();
		}
	}
}
