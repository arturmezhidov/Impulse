using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Advertisements
{
	public class AdvertMaterial
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Advert> Adverts { get; set; }

		public AdvertMaterial()
		{
			Adverts = new HashSet<Advert>();
		}
	}
}