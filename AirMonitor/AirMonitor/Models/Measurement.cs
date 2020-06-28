using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Models
{
	public struct Measurement
	{
		public int CurrentDisplayValue { get; set; }
		public MeasurementItem Current { get; set; }
		public MeasurementItem[] History { get; set; }
		public MeasurementItem[] Forecast { get; set; }

		public Station Station { get; set; }
	}
}
