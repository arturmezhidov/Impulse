using System;

namespace Impulse.Presenter.WebServices.Models.Services
{
	public class ServiceOrderDetailsModel
	{
		public string Description { get; set; }

		public bool IsApprove { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ApproveDate { get; set; }

		public string Address { get; set; }

		public virtual ServiceViewModel Service { get; set; }
	}
}