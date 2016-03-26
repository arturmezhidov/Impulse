using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Services
{
	public class ServicesCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }

		public virtual ICollection<Service> Services { get; set; }

		public ServicesCategory()
		{
			Services = new HashSet<Service>();
		}
	}
}