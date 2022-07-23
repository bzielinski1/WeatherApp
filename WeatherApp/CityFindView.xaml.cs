using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
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
    /// Pulls from Weather API with an array of cities then determines if it should populate the table based off cities temperature
    /// </summary>
    public partial class CityFindView : Page
    {
        DataTable cities = new DataTable();
        public CityFindView(int maxV, int minV)
        {
            InitializeComponent();
            populate_Table(maxV, minV);
        }

        private void populate_Table(int maxV, int minV) // creates and populates the table
        {

            cities.Columns.Add("City", typeof(string));
            cities.Columns.Add("Max Temp", typeof(float));
            cities.Columns.Add("Min Temp", typeof(float));
            cities.Columns.Add("Description", typeof(string));

            API_findcities(maxV, minV); // function for populating the rows

            CityGrid.ItemsSource = cities.DefaultView;
        }

        private async void API_findcities(int maxV, int minV) // uses an array of cities and loops through calling the API and filling the table
        {
            int flag = 0;
            string[] City_array = { "Los Angeles", "Seattle", "Salt Lake City", "Abluquerque", "Denver", "Fargo", "Dallas", "Chicago", "Nashville", "Destin", "Detroit", "Miami", "Charlotte", "DC", "New York" };

            var client = new HttpClient();

            foreach (string city in City_array) // loop through each city in the array
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + city + "/today?unitGroup=metric&key=27DAQTLU3LHGM33WX7LSQYP2X&contentType=json");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode(); // Throw an exception if error
                var body = await response.Content.ReadAsStringAsync();
                dynamic weather = JsonConvert.DeserializeObject(body); // tuns json data into .net object to then easily be converted into values

                string tmax = weather.days[0].tempmax.ToString(); // setting temperature variables
                double val_max = Convert.ToDouble(tmax);
                string tmin = weather.days[0].tempmin.ToString();
                double val_min = Convert.ToDouble(tmin);

                if (val_max <= maxV && val_min >= minV) // if cities temperature is in the paramters then it is added to the table
                {
                    cities.Rows.Add(city, val_max, val_min, weather.days[0].description.ToString());
                    flag++;
                }
            }
            if (flag == 0) // if there is no cities it will fill the first row with this
            {
                cities.Rows.Add("N/A", 0, 0, "No city fits your description");
            }
        }
    }
}
