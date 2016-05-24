﻿using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Tipographies
{
	public class KindViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Icon { get; set; }
	}
}