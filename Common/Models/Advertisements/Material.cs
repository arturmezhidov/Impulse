using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Advertisements
{
	[Table("Advertisements_Materials")]
	public class Material
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		public ICollection<Advert> Adverts { get; set; }

		public Material()
		{
			Adverts = new HashSet<Advert>();
		}
	}
}