using Bogus;
using Newtonsoft.Json;
using Project_Work_WPF.Commands;
using Project_Work_WPF.Models;
using Project_Work_WPF.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_WPF.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	class Admin_UserPage_ViewModel : BaseViewModel, IPageViewModel
	{
		public static double TotalProfit { get; set; } = 0;
		public static ObservableCollection<Driver> Drivers { get; set; } = new ObservableCollection<Driver>();

		public Admin_UserPage_ViewModel()
		{
			if (!File.Exists("Drivers.json"))
			{
				GetSampleTableData();
			}
			else {
				var jsonstr = File.ReadAllText("Drivers.json");
				Drivers = JsonConvert.DeserializeObject<ObservableCollection<Driver>>(jsonstr);
			}
		}

		static Predicate<object> DeleteDriver_Predicate = new Predicate<object>(x => selecteditem != null);

		public static object selecteditem { get; set; }

		public static int customerId = 1;

		static Random random = new Random();

		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		public static string GetCarNumber()
		{
			string Number = random.Next(0, 99).ToString() +
							new string(Enumerable.Repeat(chars, 2)
							.Select(s => s[random.Next(s.Length)]).ToArray()) +
							random.Next(100, 999).ToString();

			return Number;
		}

		private static void GetSampleTableData()
		{
			Random random = new Random();

			var userFaker = new Faker<Driver>()
				.CustomInstantiator(f => new Driver(customerId++.ToString()))
				.RuleFor(o => o.Age, f => random.Next(18, 50))
				.RuleFor(o => o.Name, f => f.Person.FirstName)
				.RuleFor(o => o.Surname, f => f.Person.LastName)
				.RuleFor(o => o.Email, (f, u) => f.Internet.Email(u.Name, u.Surname))
				.RuleFor(o => o.CarNumber, f => GetCarNumber());

			var drivers = userFaker.Generate(30);

			foreach (var item in drivers)
			{
				Drivers.Add(item);
			}

		}

		public RelayCommand Add_Driver_Command { get; set; } = new RelayCommand(x =>
		{
			Mediator.Notify("GoTo_AddDriver", "");
		});

		public RelayCommand DeleteDriver_Command { get; set; } = new RelayCommand(
			x =>
			{
				Admin_UserPage_ViewModel.Drivers.Remove((selecteditem as Driver));
				var str = JsonConvert.SerializeObject(Admin_UserPage_ViewModel.Drivers, Formatting.Indented);
				File.WriteAllText("Drivers.json", str);
			}, DeleteDriver_Predicate 
		);

	}
}
