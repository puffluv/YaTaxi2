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
	class Admin_Page_Company_Statistic_ViewModell : BaseViewModel, IPageViewModel
	{
		public static double TotalProfit { get; set; } = 0;
		public static ObservableCollection<Month> Months { get; set; } = new ObservableCollection<Month>();
	}
}
