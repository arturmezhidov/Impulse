using System;

namespace Impulse.Common.Models
{
	public interface IOrderable
	{
		bool IsApprove { get; set; }
		bool IsUser { get; set; }
		DateTime CreatedDate { get; set; }
	}
}