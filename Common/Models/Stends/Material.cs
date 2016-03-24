using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Stends
{
	public class Material
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Stend> Stends { get; set; }

		public Material()
		{
			Stends = new HashSet<Stend>();
		}
	}
}