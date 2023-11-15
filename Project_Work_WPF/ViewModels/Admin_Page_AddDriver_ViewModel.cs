using Newtonsoft.Json;
using Project_Work_WPF.Commands;
using Project_Work_WPF.Models;
using Project_Work_WPF.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_WPF.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	class Admin_Page_AddDriver_ViewModel : BaseViewModel, IPageViewModel
	{
		public static string Name { get; set; } = string.Empty;
		public static string Surname { get; set; } = string.Empty;
		public static string Email { get; set; } = string.Empty;
		public static int Age { get; set; } = 18;
		


		static Predicate<object> AddDriver_Predicate = new Predicate<object>(x => Name != string.Empty && Surname != string.Empty && Email != string.Empty);

		



		public RelayCommand AddDriver_Command { get; set; } = new RelayCommand(
			x =>
			{
				Admin_UserPage_ViewModel.Drivers.Add(new Models.Driver(Name, Surname, Email, Age, (Admin_UserPage_ViewModel.customerId).ToString()));
				if (!File.Exists("Drivers.json")) {
					File.Create("Drivers.json");
				}
				var str = JsonConvert.SerializeObject(Admin_UserPage_ViewModel.Drivers, Formatting.Indented);
				File.WriteAllText("Drivers.json", str);
				Mediator.Notify("GoToAdmin_UserPage", "");
			}, AddDriver_Predicate
		);

		public RelayCommand GoTo_Drivers { get; set; } = new RelayCommand(
		x =>
		{
			Mediator.Notify("GoToAdmin_UserPage", "");
		});
	}
}
