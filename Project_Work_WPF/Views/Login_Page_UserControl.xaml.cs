using Project_Work_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
	/// Interaction logic for Login_Page_UserControl.xaml
	/// </summary>
	public partial class Login_Page_UserControl : UserControl
	{
		SolidColorBrush myBrush = new SolidColorBrush(Colors.Red);
		SolidColorBrush myBrush_2 = new SolidColorBrush(Colors.Yellow);
		public Login_Page_UserControl()
		{
			InitializeComponent();
			MainViewModel.Logged_As = "User";
		} 
		private void Toggle_Checked(object sender, RoutedEventArgs e)
		{
			MainViewModel.Logged_As = "Admin";
			Toggle.Background = myBrush_2;
			Username_TextBox.Text = string.Empty;
			Password_Box.Password = string.Empty;
			Password_2Box.Text = string.Empty;
		}
		private void Toggle_UnChecked(object sender, RoutedEventArgs e)
		{
			MainViewModel.Logged_As = "User";
			Username_TextBox.Text = string.Empty;
			Password_Box.Password = string.Empty;
			Password_2Box.Text = string.Empty;
		}

        private void Password_2Box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
