using Project_Work_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_WPF.Models
{
	public class Driver
	{
		public Driver(string DriverID)
		{
			this.id = DriverID;
		}

		public Driver() { }

		public Driver(string name, string surname, string email, int age, string ID)
		{
			Name = name;
			Surname = surname;
			Email = email;
			Age = age;
			id = ID;
			CarNumber = Admin_UserPage_ViewModel.GetCarNumber();
		}

		public void setPoint(float point)
		{
			var totalpoint = Point * Given_Point_Count;
			Given_Point_Count++;
			totalpoint += point;
			Point = totalpoint / Given_Point_Count;
		}
		public int Given_Point_Count { get; set; } = 0;
		public float Point { get; set; } = 0;
		public string id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public int Age { get; set; }

		public string CarNumber { get; set; }
	}
}
