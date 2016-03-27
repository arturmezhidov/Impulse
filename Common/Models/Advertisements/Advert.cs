using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Advertisements
{
	[Table("Advertisements_Adverts")]
	public class Advert
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Number { get; set; }

		[MaxLength(1024)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Image { get; set; }

		public int MaterialId { get; set; }
		public int CategoryId { get; set; }

		[Required]
		public virtual Material Material { get; set; }
		[Required]
		public virtual Category Category { get; set; }
	}
}