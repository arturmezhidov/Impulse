using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Contacts
{
	[Table("Contacts_Phones")]
	public class Phone
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Operator { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Number { get; set; }
	}
}