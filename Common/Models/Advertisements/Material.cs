using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Advertisements
{
	public class Material
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Advert> Adverts { get; set; }

		public Material()
		{
			Adverts = new HashSet<Advert>();
		}
	}
}