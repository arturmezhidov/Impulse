using System;

namespace Impulse.Presenter.WebServices.Models.Application
{
	public class FeedbackViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Contacts { get; set; }
		public string Message { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsApprove { get; set; }
		public DateTime ApprovedDate { get; set; }
	}
}