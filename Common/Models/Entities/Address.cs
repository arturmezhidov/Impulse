using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class Address : BaseEntity
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

		public ContactType Type { get; set; }

		public string ProfileUserId { get; set; }
		public virtual ProfileUser ProfileUser { get; set; }
	}
}