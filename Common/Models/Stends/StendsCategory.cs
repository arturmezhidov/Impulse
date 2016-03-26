using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Stends
{
	public class StendsCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }

		public virtual ICollection<Stend> Stends { get; set; }

		public StendsCategory()
		{
			Stends = new HashSet<Stend>();
		}
	}
}