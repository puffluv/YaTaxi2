using Project_Work_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Work_WPF.Views
{
	/// <summary>
	/// Interaction logic for Admin_Page_AddDriver_UserControl.xaml
	/// </summary>
	public partial class Admin_Page_AddDriver_UserControl : UserControl
	{
		public Admin_Page_AddDriver_UserControl()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Admin_Page_AddDriver_ViewModel.Name = string.Empty;
			Admin_Page_AddDriver_ViewModel.Surname = string.Empty;
			Admin_Page_AddDriver_ViewModel.Email = string.Empty;
			Admin_Page_AddDriver_ViewModel.Age = 18; 
		}
	}
}
