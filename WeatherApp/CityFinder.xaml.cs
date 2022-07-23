using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for CityFinder.xaml
    /// </summary>
    public partial class CityFinder : Page
    {
        public CityFinder()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // sets MinTemp and MaxTemp from the textboxes then sends them to the CityFindView Page
        {
            int maxValue = Int32.Parse(maxTemp.Text.ToString());
            int minValue = Int32.Parse(minTemp.Text.ToString());
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new CityFindView(maxValue, minValue));
        }

    }
}
