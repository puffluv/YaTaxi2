using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_WPF.Models
{
	public class Departure
	{
		public DateTime Date { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public TimeSpan Duration { get; set; }
		public string Cost { get; set; }
		public float Distance { get; set; }
		public Driver driver { get; set; }
	}
}
