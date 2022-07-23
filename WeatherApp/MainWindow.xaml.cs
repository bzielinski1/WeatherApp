using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Web.Helpers;
using System.Text.Json;
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
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace WeatherApp // remove commentented code to fill data base with historic weather data
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        //SqlCommand cmd;
        //SqlConnection con;
        public MainWindow()
        {
            InitializeComponent();
            /*Load_Api(); //calls Load_Api to fill up database with historic data

            con = new SqlConnection(@"Data Source=DESKTOP-R73KJR5\SQLEXPRESS;Initial Catalog=Weather;Integrated Security=True"); //sets up SQL connection
            con.Open();
            cmd = new SqlCommand("");*/

            _mainFrame.Navigate(new LandingPage());
        }
        // This was a test of the API and loading historic data in database
        // you can add any cities or dates you want 
        /*private async void Load_Api()
        {
            string[] City_array = { "Los Angeles", "Seattle", "Salt Lake City", "Abluquerque", "Denver", "Fargo", "Dallas", "Chicago", "Nashville", "Destin", "Detroit", "Miami", "Charlotte", "DC", "New York" };
            string[] Date_array = { "2022-01-01", "2022-02-01", "2022-03-01", "2022-04-01", "2022-05-01", "2022-06-01", "2022-07-01" };
            int i = 0;

            var client = new HttpClient();

            foreach (string city in City_array)
            {
                foreach (string date in Date_array)
                {
                    i++;
                    var request = new HttpRequestMessage(HttpMethod.Get, "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + city + "/" + date + "/" + date + "?"+ "unitGroup=metric&include=current&key=27DAQTLU3LHGM33WX7LSQYP2X&contentType=json");
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode(); // Throw an exception if error
                    var body = await response.Content.ReadAsStringAsync();
                    dynamic weather = JsonConvert.DeserializeObject(body);
                    //MessageBox.Show(weather.days[0].tempmax.ToString(), city); // if the api call is taking to long run this so it doesnt skip inserting into database
                    load_HistoricTable(i, city, date, weather.days[0].tempmax.ToString(), weather.days[0].tempmin.ToString());
                }
            }
        }

        public void load_HistoricTable(int id, string city, string date, string tmax, string tmin)
        {
            double val_max = Convert.ToDouble(tmax);
            double val_min = Convert.ToDouble(tmin);
            string query = "INSERT INTO HistTemp (id, City, Date, maxTemp, minTemp)";
            query += " VALUES (@id, @City, @Date, @maxTemp, @minTemp)";
            
            SqlCommand myCommand = new SqlCommand(query, con);
            myCommand.Parameters.AddWithValue("@id", id);
            myCommand.Parameters.AddWithValue("@City", city);
            myCommand.Parameters.AddWithValue("@Date", date);
            myCommand.Parameters.AddWithValue("@maxTemp", ((decimal)val_max));
            myCommand.Parameters.AddWithValue("@minTemp", ((decimal)val_min));

            myCommand.ExecuteNonQuery();
        }*/
    }
}
