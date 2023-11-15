using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_WPF.Models
{
	public class Person
	{
		public  string Username { get; set; }
		public string Password { get; set; }
		public Person(string username, string password)
		{
			Username = username;
			Password = password;
		}
	}
}
