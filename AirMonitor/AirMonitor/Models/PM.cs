﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Models
{
	public struct PM
	{
		public int Value { get; set; }
		public int Percentage { get; set; }

		public PM(int value, int percentage)
		{
			Value = value;
			Percentage = percentage;
		}
	}
}
