using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.OurWorks
{
	public class WorkItemsCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }

		public virtual ICollection<WorkItem> Items { get; set; }

		public WorkItemsCategory()
		{
			Items = new HashSet<WorkItem>();
		}
	}
}