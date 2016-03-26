using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Advertisements
{
	public class AdvertsCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }

		public virtual ICollection<Advert> Adverts { get; set; }

		public AdvertsCategory()
		{
			Adverts = new HashSet<Advert>();
		}
	}
}