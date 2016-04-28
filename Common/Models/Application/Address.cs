using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Application
{
	[Table("Addresses")]
	public class Address : BaseItem
	{

		[MaxLength(1024)]
		public string Country { get; set; }

		[MaxLength(1024)]
		public string Region { get; set; }

		[Required]
		[MaxLength(1024)]
		public string City { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Street { get; set; }

		[Required]
		[MaxLength(1024)]
		public string House { get; set; }

		public double Longitube { get; set; }

		public double Latitube { get; set; }
	}
}