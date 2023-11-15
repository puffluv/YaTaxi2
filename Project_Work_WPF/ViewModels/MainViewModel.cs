using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bogus;
using Project_Work_WPF.CustomExceptions;
using Project_Work_WPF.Models;
using Project_Work_WPF.Navigation;
using PropertyChanged;

namespace Project_Work_WPF.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	public class MainViewModel : BaseViewModel
	{
		public static string Logged_As = "User";

		static List<Models.Person> Users = new List<Models.Person>();
		static Models.Person Admin = new Models.Person("admin", "admin");
		static List<Driver> Drivers = new List<Driver>();

		public static void Add_User(string username, string password)
		{
			if (Users.Exists(x => x.Username == username))
			{
				throw new InvalidDataException();
			}
			else
			{
				Models.Person User = new Models.Person(username, password);
				Users.Add(User);
			}
		}

		public static bool Check_User(string username, string password)
		{

			if (Users.Exists(x => x.Username == username && x.Password == password))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool Check_Admin(string username, string password)
		{

			if (Admin.Password == password && Admin.Username == username)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		private List<IPageViewModel> _pageViewModels;

		public List<IPageViewModel> PageViewModels
		{
			get
			{
				if (_pageViewModels == null)
					_pageViewModels = new List<IPageViewModel>();

				return _pageViewModels;
			}
		}

		public IPageViewModel _currentPageViewModel { get; set; }

		public IPageViewModel CurrentPageViewModel
		{

			get
			{
				return _currentPageViewModel;
			}

			set
			{
				_currentPageViewModel = value;
				OnPropertyChanged("CurrentPageViewModel");
			}
		}

		private void ChangeViewModel(IPageViewModel viewModel)
		{
			if (!PageViewModels.Contains(viewModel))
				PageViewModels.Add(viewModel);

			CurrentPageViewModel = PageViewModels
				.FirstOrDefault(vm => vm == viewModel);
		}

		private void GoToLogIn(object obj)
		{
			(PageViewModels[0] as Login_Page_ViewModel).Password = string.Empty;
			(PageViewModels[0] as Login_Page_ViewModel).Username = string.Empty;
			(PageViewModels[0] as Login_Page_ViewModel).password_box_visibility = System.Windows.Visibility.Visible;
			(PageViewModels[0] as Login_Page_ViewModel).password_box_visibility_2 = System.Windows.Visibility.Collapsed;
			ChangeViewModel(PageViewModels[0]);
		}

		private void GoToUser(object obj)
		{
			(PageViewModels[1] as User_Page_ViewModel).Route.Clear();
			(PageViewModels[1] as User_Page_ViewModel).From = string.Empty;
			(PageViewModels[1] as User_Page_ViewModel).To = string.Empty;
			(PageViewModels[1] as User_Page_ViewModel).Price = string.Empty;
			User_Page_ViewModel.rotate_cliked = false;
			(PageViewModels[1] as User_Page_ViewModel).GetCurrentLocation();
			ChangeViewModel(PageViewModels[1]);
		}

		private void GoToRegister(object obj)
		{
			(PageViewModels[2] as Register_Page_ViewModel).Passwordd = string.Empty;
			(PageViewModels[2] as Register_Page_ViewModel).password_box_visibility = System.Windows.Visibility.Visible;
			(PageViewModels[2] as Register_Page_ViewModel).password_box_visibility_2 = System.Windows.Visibility.Collapsed;
			(PageViewModels[2] as Register_Page_ViewModel).Hidden = false;
			ChangeViewModel(PageViewModels[2]);
		}

		private void GoToHistory(object obj)
		{
			ChangeViewModel(PageViewModels[3]);
		}

		private void GoToAdmin(object obj)
		{
			ChangeViewModel(PageViewModels[4]);
		}


		public MainViewModel()
		{
			// Add available pages and set page 
			PageViewModels.Add(new Login_Page_ViewModel());
			PageViewModels.Add(new User_Page_ViewModel());
			PageViewModels.Add(new Register_Page_ViewModel());
			PageViewModels.Add(new History_Page_ViewModel());
			PageViewModels.Add(new Admin_Page_ViewModel());
			ChangeViewModel(PageViewModels[0]);


			Mediator.Subscribe("GoToLogIn", GoToLogIn);
			Mediator.Subscribe("GoToUser", GoToUser);
			Mediator.Subscribe("GoToRegister", GoToRegister);
			Mediator.Subscribe("GoToHistory", GoToHistory);
			Mediator.Subscribe("GoToAdmin", GoToAdmin);
		}

	}
}
