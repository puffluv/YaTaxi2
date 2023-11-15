using Project_Work_WPF.Commands;
using Project_Work_WPF.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_WPF.ViewModels
{
	class Admin_Page_ViewModel : BaseViewModel, IPageViewModel
	{
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

		private void GoToAdmin_UserPage(object obj)
		{
			ChangeViewModel(PageViewModels[0]);
		}
		private void GoToAdmin_UseronMap(object obj)
		{
			(PageViewModels[1] as Admin_Page_DriverOnMap_ViewModel).SetDriversOnMap();
			ChangeViewModel(PageViewModels[1]);
		}

		private void GoTo_AddDriver(object obj)
		{
			Admin_Page_AddDriver_ViewModel.Name = string.Empty;
			Admin_Page_AddDriver_ViewModel.Surname = string.Empty;
			Admin_Page_AddDriver_ViewModel.Email = string.Empty;
			Admin_Page_AddDriver_ViewModel.Age = 18;
			ChangeViewModel(PageViewModels[2]);
		}

		private void GoTo_SetPrice(object obj)
		{ 
			ChangeViewModel(PageViewModels[3]);
		}


		private void GoTo_Statistic(object obj)
		{
			ChangeViewModel(PageViewModels[4]);
		}





		public RelayCommand GoToAdmin_User { get; set; } = new RelayCommand(x =>
		  {
			  Mediator.Notify("GoToAdmin_UserPage", "");
		  }
		);

		public RelayCommand GoToAdmin_UserOnMap { get; set; } = new RelayCommand(x =>
		{
			Mediator.Notify("GoTo_UserOnMap", "");
		}
		);

		public RelayCommand GoToAdmin_SetPrice { get; set; } = new RelayCommand(x =>
		{
			Mediator.Notify("GoTo_SetPrice", "");
		}
		);

		public RelayCommand GoTo_Login { get; set; } = new RelayCommand(x =>
			{
				Mediator.Notify("GoToLogIn", "");
			}
		);

		public RelayCommand GoToCompany_Statistic { get; set; } = new RelayCommand(x =>
		{
			Mediator.Notify("GoTo_Statistic", "");
		}
		);


		public Admin_Page_ViewModel()
		{
			PageViewModels.Add(new Admin_UserPage_ViewModel());
			PageViewModels.Add(new Admin_Page_DriverOnMap_ViewModel());
			PageViewModels.Add(new  Admin_Page_AddDriver_ViewModel());
			PageViewModels.Add(new Admin_Page_SetPrice_ViewModel());
			PageViewModels.Add(new Admin_Page_Company_Statistic_ViewModell());

			Mediator.Subscribe("GoToAdmin_UserPage", GoToAdmin_UserPage);
			Mediator.Subscribe("GoTo_UserOnMap", GoToAdmin_UseronMap);
			Mediator.Subscribe("GoTo_AddDriver", GoTo_AddDriver);
			Mediator.Subscribe("GoTo_SetPrice", GoTo_SetPrice);
			Mediator.Subscribe("GoTo_Statistic", GoTo_Statistic);

			Mediator.Notify("GoToAdmin_UserPage", "");

		}
	}
}
