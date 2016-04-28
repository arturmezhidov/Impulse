﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Advertisements
{
	[Table("Advertisements_Adverts")]
	public class Advert : BaseItem
	{

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Number { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Image { get; set; }

		public int MaterialId { get; set; }
		public virtual Material Material { get; set; }

		public int TypeId { get; set; }
		public virtual Type Type { get; set; }
	}
}