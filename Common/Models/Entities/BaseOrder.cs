using System;

namespace Impulse.Common.Models.Entities
{
	public class BaseOrder : BaseEntity, IOrderable
	{
		public string Name { get; set; }
		public string Contacts { get; set; }
		public string Description { get; set; }
		public bool IsApprove { get; set; }
		public bool IsUser { get; set; }
		public DateTime CreatedDate { get; set; }

		public string ProfileUserId { get; set; }
		public virtual ProfileUser ProfileUser { get; set; }
	}
}
