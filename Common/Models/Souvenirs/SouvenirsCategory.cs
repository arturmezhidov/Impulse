using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Souvenirs
{
	public class SouvenirsCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }

		public virtual ICollection<Souvenir> Souvenirs { get; set; }

		public SouvenirsCategory()
		{
			Souvenirs = new HashSet<Souvenir>();
		}
	}
}
