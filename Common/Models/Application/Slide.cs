using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Application
{
	[Table("Slides")]
	public class Slide : BaseItem
	{
		[MaxLength(1024)]
		[Required]
		public string Image { get; set; }

		[MaxLength(1024)]
		public string Url { get; set; }

		[MaxLength(1024)]
		public string About { get; set; }
	}
}
