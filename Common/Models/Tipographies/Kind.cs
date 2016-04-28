﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Tipographies
{
	[Table("Tipographies_Kinds")]
	public class Kind : BaseItem, ISortable
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Icon { get; set; }

		public int SortingNumber { get; set; }

		public virtual ICollection<Tipography> Tipographies { get; set; }

		public Kind()
		{
			Tipographies = new HashSet<Tipography>();
		}
	}
}