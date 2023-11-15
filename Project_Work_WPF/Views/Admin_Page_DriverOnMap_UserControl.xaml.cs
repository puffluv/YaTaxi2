using Microsoft.Maps.MapControl.WPF;
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
	/// Interaction logic for Admin_Page_DriverOnMap_UserControl.xaml
	/// </summary>
	public partial class Admin_Page_DriverOnMap_UserControl : UserControl
	{
		public Admin_Page_DriverOnMap_UserControl()
		{
			InitializeComponent();
		} 

		private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var mousePosition = e.GetPosition(Map);
			Microsoft.Maps.MapControl.WPF.Location pinLocation = (sender as Map).ViewportPointToLocation(mousePosition);

			Pushpin a = new Pushpin();
			a.Location = pinLocation;
			Map.Children.Add(a);
		}
	}
}
