using System.Collections.Generic;
using Impulse.Presenter.WebServices.Models.Advertisements;
using Impulse.Presenter.WebServices.Models.Services;

namespace Impulse.Presenter.WebServices.Models.Application
{
	public class ProfileUserViewModel
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public virtual ICollection<AddressViewModel> Addresses { get; set; }

		public virtual ICollection<PhoneViewModel> Phones { get; set; }

		public virtual ICollection<EmailViewModel> Emails { get; set; }

		public virtual ICollection<SocialViewModel> Social { get; set; }

		public virtual ICollection<AdvertsOrderViewModel> AdvertsOrders { get; set; }

		public virtual ICollection<SouvenirOrderViewModel> SouvenirOrders { get; set; }

		public virtual ICollection<StendOrderViewModel> StendOrders { get; set; }

		public virtual ICollection<ServiceOrderViewModel> ServiceOrders { get; set; }
	}
}