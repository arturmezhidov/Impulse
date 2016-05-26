using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Entities
{
	public class ProfileUser
	{
		[Key]
		[ForeignKey("ApplicationUser")]
		public string Id { get; set; }

		[MaxLength(1024)]
		public string Name { get; set; }

		[MaxLength(1024)]
		public string Surname { get; set; }

		public ApplicationUser ApplicationUser { get; set; }

		public virtual ICollection<Address> Addresses { get; set; }
		public virtual ICollection<Phone> Phones { get; set; }
		public virtual ICollection<Email> Emails { get; set; }
		public virtual ICollection<Social> Social { get; set; }
		public virtual ICollection<AdvertsOrder> AdvertsOrders { get; set; }
		public virtual ICollection<SouvenirOrder> SouvenirOrders { get; set; }
		public virtual ICollection<StendOrder> StendOrders { get; set; }
		public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }

		public ProfileUser()
		{
			Addresses = new HashSet<Address>();
			Phones = new HashSet<Phone>();
			Emails = new HashSet<Email>();
			Social = new HashSet<Social>();
			AdvertsOrders = new HashSet<AdvertsOrder>();
			SouvenirOrders = new HashSet<SouvenirOrder>();
			StendOrders = new HashSet<StendOrder>();
			ServiceOrders = new HashSet<ServiceOrder>();
		}
	}
}