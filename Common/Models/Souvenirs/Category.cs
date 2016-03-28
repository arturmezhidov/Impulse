using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Souvenirs
{
	[Table("Souvenirs_Categories")]
	public class SouvenirsCategory
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Icon { get; set; }

		public virtual ICollection<Souvenir> Souvenirs { get; set; }

		public SouvenirsCategory()
		{
			Souvenirs = new HashSet<Souvenir>();
		}
	}
}
