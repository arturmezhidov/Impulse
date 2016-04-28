using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Stends
{
	[Table("Stends_Materials")]
	public class Material : BaseItem
	{
		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		public ICollection<Stend> Stends { get; set; }

		public Material()
		{
			Stends = new HashSet<Stend>();
		}
	}
}