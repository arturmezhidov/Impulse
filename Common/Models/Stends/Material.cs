using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Stends
{
	[Table("Stends_Materials")]
	public class Material
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

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