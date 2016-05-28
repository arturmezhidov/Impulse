using System;

namespace Impulse.Common.Models
{
	public interface IOrderable
	{
		string Description { get; set; }
		bool IsApprove { get; set; }
		DateTime CreatedDate { get; set; }
		DateTime ApprovedDate { get; set; }
	}
}