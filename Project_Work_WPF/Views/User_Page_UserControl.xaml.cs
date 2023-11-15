using BingMapsRESTToolkit;
using Microsoft.Maps.MapControl.WPF;
using Project_Work_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
	/// Interaction logic for User_Page_UserControl.xaml
	/// </summary>
	public partial class User_Page_UserControl : UserControl
	{

		public string SelectedTxtBox { get; set; }

		public static Microsoft.Maps.MapControl.WPF.Location From_Location = new Microsoft.Maps.MapControl.WPF.Location();

		public static Microsoft.Maps.MapControl.WPF.Location To_Location = new Microsoft.Maps.MapControl.WPF.Location();

		public User_Page_UserControl()
		{
			InitializeComponent();
		}

		private async void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var mousePosition = e.GetPosition(m);

			Microsoft.Maps.MapControl.WPF.Location pinLocation = (sender as Map).ViewportPointToLocation(mousePosition);
			Uri geocodeRequest = new Uri("http://dev.virtualearth.net/REST/v1/Locations/" + pinLocation.Latitude.ToString() + "," + pinLocation.Longitude.ToString() +
						"?key=" + ConfigurationManager.AppSettings["apiKey"]);


			Response r = await User_Page_ViewModel.GetResponse(geocodeRequest);

			if (SelectedTxtBox == "From")
			{
				foreach (var item in m.Children)
				{
					(m.DataContext as User_Page_ViewModel).From_Pushpin_Location = pinLocation;
					(m.DataContext as User_Page_ViewModel).From_Pushpin_Visibility = Visibility.Visible;
					if (item is MapItemsControl s)
					{
						if (s.ItemsSource is ObservableCollection<UIElement> a)
						{
							a.Clear();
						}
					}
				}
				From_Textbox.Text = ((BingMapsRESTToolkit.Location)r.ResourceSets[0].Resources[0]).Address.AddressLine + " Novosibirsk";
				From_Location = pinLocation;
			}

			else if (SelectedTxtBox == "To")
			{
				foreach (var item in m.Children)
				{
					(m.DataContext as User_Page_ViewModel).To_Pushpin_Location = pinLocation;
					(m.DataContext as User_Page_ViewModel).To_Pushpin_Visibility = Visibility.Visible;
					if (item is MapItemsControl s)
					{
						if (s.ItemsSource is ObservableCollection<UIElement> a)
						{
							a.Clear();
						}
					}
 

				}
				To_Textbox.Text = ((BingMapsRESTToolkit.Location)r.ResourceSets[0].Resources[0]).Address.AddressLine + " Novosibirsk";
				To_Location = pinLocation;
			}

			//m.Children.Add(From_Pushpin);
			//m.Children.Add(To_Pushpin);
		}

		private void From_Textbox_GotFocus(object sender, RoutedEventArgs e)
		{
			SelectedTxtBox = "From";
		}

		private void To_Textbox_GotFocus(object sender, RoutedEventArgs e)
		{
			SelectedTxtBox = "To";
		}

    }
}
