using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleAppMobileDev
{
	//TodoIteam model
	public class TodoItem
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool IsComplete { get; set; }
		public bool IsImportant { get; set; }
		public double gps_lat { get; set; }
		public double gps_long { get; set; }
	}
}
