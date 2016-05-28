using System;
using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class BaseGuestOrder : BaseEntity, IOrderable
	{
		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Contacts { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		public bool IsApprove { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ApprovedDate { get; set; }
	}
}
