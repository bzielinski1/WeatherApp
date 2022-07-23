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
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace WeatherApp
{
    /// <summary>
    /// Two drop down menues to chose from cities that are quered and filled by sqlserver table
    /// </summary>
    public partial class CityCompare : Page
    {
        public CityCompare()
        { 
            InitializeComponent();
            Fill_combobox();
        }

        private void Fill_combobox() // SQL query to grab all the cities in the database and sets them to both comboboxes
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-R73KJR5\SQLEXPRESS;Initial Catalog=Weather;Integrated Security=True"); //SQL connection and query
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Distinct City FROM HistTemp", conn);

            DataTable dt = new DataTable(); // fills table with sql data
            da.Fill(dt);

            City1.ItemsSource = dt.DefaultView; //assigns combobox datatable values
            City1.DisplayMemberPath = "City";
            City1.SelectedValuePath = "City";

            City2.ItemsSource = dt.DefaultView;
            City2.DisplayMemberPath = "City";
            City2.SelectedValuePath = "City";
            conn.Close();
        }
        private void CompareButton_Click(object sender, RoutedEventArgs e) // sets the combobox values and navigates to the CompareView page
        {
            string firstCity = City1.Text;
            string secondCity = City2.Text;
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new CompareView(firstCity, secondCity));
        }

    }
}
