using System;
using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class BaseOrder : BaseEntity, IOrderable
	{
		[MaxLength(2048)]
		public string Description { get; set; }

		public bool IsApprove { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ApproveDate { get; set; }

		public string ProfileUserId { get; set; }
		public virtual ProfileUser ProfileUser { get; set; }
	}
}
