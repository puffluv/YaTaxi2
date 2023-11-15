using Project_Work_WPF.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_WPF.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	class Admin_Page_SetPrice_ViewModel : BaseViewModel, IPageViewModel
	{
		public static double XValue { get; set; } = 43;
	}
}
