using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Models
{
	public struct AirQualityIndex
	{
		public string Name { get; set; }
		public string Value { get; set; }
		public string Level { get; set; }
		public string Description { get; set; }
		public string Advice { get; set; }
		public string Color { get; set; }
	}

}
