using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Advertisements
{
	public class Advert
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Number { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }

		public int MaterialId { get; set; }
		public virtual AdvertMaterial Material { get; set; }

		public int CategoryId { get; set; }
		public virtual AdvertsCategory Category { get; set; }
	}
}