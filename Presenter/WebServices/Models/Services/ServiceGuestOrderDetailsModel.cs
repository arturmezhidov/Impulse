using System;

namespace Impulse.Presenter.WebServices.Models.Services
{
	public class ServiceGuestOrderDetailsModel
	{
		public string Name { get; set; }

		public string Contacts { get; set; }

		public string Description { get; set; }

		public bool IsApprove { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ApproveDate { get; set; }

		public string Address { get; set; }

		public ServiceViewModel Service { get; set; }
	}
}