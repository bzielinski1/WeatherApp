using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;

namespace WeatherApp
{
    /// <summary>
    /// Grabs all historic data for the two cities picked fills a datatable then creates a chart
    /// </summary>
    public partial class CompareView : Page
    {
        public CompareView(string city1, string city2) // load elements and set the series titles
        {
            InitializeComponent();
            ((LineSeries)mcChart.Series[0]).Title = city1 + " Max Temp";
            ((LineSeries)mcChart.Series[1]).Title = city1 + " Min Temp";
            ((LineSeries)mcChart.Series[2]).Title = city2 + " Max Temp";
            ((LineSeries)mcChart.Series[3]).Title = city2 + " Min Temp";
            Load_Chart(city1, city2); // calls function to fill the chart with data
        }

        private void Load_Chart(string city1, string city2) // Queries SQL table filles a datatable that is inserted into KeyValuePair to assign to the chart
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-R73KJR5\SQLEXPRESS;Initial Catalog=Weather;Integrated Security=True"); // sql connection and queries
            conn.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT City, Date, maxTemp, minTemp FROM HistTemp WHERE City like \'" + city1 + "\';", conn);
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT City, Date, maxTemp, minTemp FROM HistTemp WHERE City like \'" + city2 + "\';", conn);
 
            DataTable dt1 = new DataTable(); // fills table with first cities data
            DataTable dt2 = new DataTable(); // fills table with second cities data
            da1.Fill(dt1);
            da2.Fill(dt2);
            conn.Close();

            KeyValuePair<string, double>[] city1max = new KeyValuePair<string, double>[7]; // initialize KeyValuePair for each series i.e. city 1 max temp, city 1 min temp, city 2...
            KeyValuePair<string, double>[] city1min = new KeyValuePair<string, double>[7];
            KeyValuePair<string, double>[] city2max = new KeyValuePair<string, double>[7];
            KeyValuePair<string, double>[] city2min = new KeyValuePair<string, double>[7];

            for (int i = 0; i < dt1.Rows.Count; i++) // loops through dataTable Rows and fills the KeyValuePair with appropriate values
            {
                city1max[i] = new KeyValuePair<string, double>(dt1.Rows[i][1].ToString(), double.Parse(dt1.Rows[i][2].ToString()));
                city1min[i] = new KeyValuePair<string, double>(dt1.Rows[i][1].ToString(), double.Parse(dt1.Rows[i][3].ToString()));
                city2max[i] = new KeyValuePair<string, double>(dt2.Rows[i][1].ToString(), double.Parse(dt2.Rows[i][2].ToString()));
                city2min[i] = new KeyValuePair<string, double>(dt2.Rows[i][1].ToString(), double.Parse(dt2.Rows[i][3].ToString()));
            }

            ((LineSeries)mcChart.Series[0]).ItemsSource = city1max; // assings series to to correlating KeyValuePair
            ((LineSeries)mcChart.Series[1]).ItemsSource = city1min;
            ((LineSeries)mcChart.Series[2]).ItemsSource = city2max;
            ((LineSeries)mcChart.Series[3]).ItemsSource = city2min;
            
        }
    }
}
