﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Common.Models.Contacts
{
	public class Address
	{
		public int Id { get; set; }
		public string Country { get; set; }
		public string Region { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public int House { get; set; }
		public string Longitube { get; set; }
		public string Latitube { get; set; }
	}
}