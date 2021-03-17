using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleAppMobileDev
{
	public class TodoItem
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool IsComplete { get; set; }
		public bool IsImportant { get; set; }
	}
}
