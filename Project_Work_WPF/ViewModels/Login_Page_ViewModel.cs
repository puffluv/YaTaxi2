using Project_Work_WPF.Commands;
using Project_Work_WPF.Navigation;
using Project_Work_WPF.Views;
using PropertyChanged;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace Project_Work_WPF.ViewModels
{

	[AddINotifyPropertyChangedInterface]
	public class Login_Page_ViewModel : BaseViewModel, IPageViewModel
	{
		public string Username { get; set; }

		public string Password { get; set; }

		bool Hidden = false;

		public System.Windows.Visibility password_box_visibility { get; set; } = System.Windows.Visibility.Visible;
		public System.Windows.Visibility password_box_visibility_2 { get; set; } = System.Windows.Visibility.Collapsed;

		private void Hide_Button_Click(object obj)
		{

			if (!Hidden)
			{
				password_box_visibility = System.Windows.Visibility.Hidden;
				password_box_visibility_2 = System.Windows.Visibility.Visible;

				Hidden = true;
			}

			else
			{
				password_box_visibility = System.Windows.Visibility.Visible;
				password_box_visibility_2 = System.Windows.Visibility.Hidden;

				Hidden = false;
			}

		}

		public Login_Page_ViewModel()
		{
			Hide = new RelayCommand(Hide_Button_Click);
		}

		private RelayCommand _goTo1;
		private RelayCommand _goTo44; 

		public RelayCommand GoTo_SignIn
		{
			get
			{
				if (MainViewModel.Logged_As == "User")
				{
					if (MainViewModel.Check_User(Username, Password))
					{

						return new RelayCommand(x =>
						{
							Username = string.Empty;
							Password = string.Empty;
							Mediator.Notify("GoToUser", "");
						});
					}

					return new RelayCommand(x =>
					{
						Error_Window error_Window = new Error_Window(); 
						error_Window.Left = Application.Current.MainWindow.Left;
						error_Window.Top = Application.Current.MainWindow.Top;

						error_Window.Left += Application.Current.MainWindow.Width / 2;
						error_Window.Top += Application.Current.MainWindow.Height / 2;

						error_Window.ShowDialog();
					});
				}

				else
				{
					if (MainViewModel.Check_Admin(Username, Password))
					{

						return new RelayCommand(x =>
						{
							Username = string.Empty;
							Password = string.Empty;
							Mediator.Notify("GoToAdmin", "");
						});
					}

					return new RelayCommand(x =>
					{
						Error_Window error_Window = new Error_Window();
						error_Window.Left = Application.Current.MainWindow.Left;
						error_Window.Top = Application.Current.MainWindow.Top;

						error_Window.Left += Application.Current.MainWindow.Width / 2;
						error_Window.Top += Application.Current.MainWindow.Height / 2;

						error_Window.ShowDialog();
					});
				}
			}
		}

		private ICommand _goTo2;

		public ICommand GoTo_Register
		{
			get
			{
				return new RelayCommand(x =>
					{
						Username = string.Empty;
						Password = string.Empty;
						Mediator.Notify("GoToRegister", "");
					});
			}

		}

		public RelayCommand Hide { get; set; }

	}
}
