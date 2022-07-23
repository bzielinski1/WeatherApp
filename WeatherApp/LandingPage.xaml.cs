using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
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
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Page
    {
        public LandingPage()
        {
            InitializeComponent();
        }
        private void Find_Click(object sender, RoutedEventArgs e) // simple navigation to CityFinder Page
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new CityFinder());
        }

        private void Compare_Click(object sender, RoutedEventArgs e) // simple navigation to CityCompare Page
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new CityCompare());
        }
    }
}
