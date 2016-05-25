using System;

namespace Impulse.Presenter.WebServices.Models.Stends
{
	public class StendGuestOrderDetailsModel
	{
		public string Name { get; set; }

		public string Contacts { get; set; }

		public string Description { get; set; }

		public bool IsApprove { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ApproveDate { get; set; }

		public int Count { get; set; }

		public virtual StendViewModel Stend { get; set; }
	}
}