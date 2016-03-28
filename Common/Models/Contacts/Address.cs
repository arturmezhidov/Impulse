using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Contacts
{
	[Table("Contacts_Addresses")]
	public class Address
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

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