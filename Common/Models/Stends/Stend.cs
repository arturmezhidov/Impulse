using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Stends
{
	public class Stend
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Number { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public int? Pockets { get; set; }
		public int? Eyelets { get; set; }
		public bool? IsBorder { get; set; }

		public int MaterialId { get; set; }
		public virtual StendsMaterial Material { get; set; }

		public int CategoryId { get; set; }
		public virtual StendsCategory Category { get; set; }
	}
}