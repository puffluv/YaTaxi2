using Project_Work_WPF.Commands;
using Project_Work_WPF.Models;
using Project_Work_WPF.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_WPF.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	class History_Page_ViewModel : BaseViewModel, IPageViewModel
	{
		public static ObservableCollection<Departure> Departures { get; set; } = new ObservableCollection<Departure>();

		private RelayCommand _goTo1;

		public RelayCommand Log_Out
		{ 
			get
			{
				return _goTo1 ?? (_goTo1 = new RelayCommand(x =>
				{
					Mediator.Notify("GoToUser", "");
				}));
			} 
		}
		bool tf = false;
		public History_Page_ViewModel()
		{
		}
	}
}
