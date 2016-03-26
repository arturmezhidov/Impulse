using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Stends
{
	public class StendsMaterial
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Stend> Stends { get; set; }

		public StendsMaterial()
		{
			Stends = new HashSet<Stend>();
		}
	}
}