using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
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

namespace GUSRekrutacja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string json = "{\"id\":1,\"nazwa\":\"Ceny\",\"id-nadrzedny-element\":727,\"id-poziom\":1,\"nazwa-poziom\":\"Dziedzina\",\"czy-zmienne\":false}";

            ThematicAreas thematicArea = JsonConvert.DeserializeObject<ThematicAreas>(json);

            Task.Run(async () =>
            {
                const string URL = @"https://api-dbw.stat.gov.pl/api/1.1.0/area/area-area?lang=pl";

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

                string response = await client.GetStringAsync(URL);

                var data = JsonConvert.DeserializeObject<ThematicAreas[]>(response);

                Thread.Sleep(1000);

                Dispatcher.Invoke(() =>
                {
                    TestDataGrid.ItemsSource = data;
                });
            });
        }

        private static async Task GetDataFromApi()
        {
            const string URL = @"https://api-dbw.stat.gov.pl/api/1.1.0/area/area-area?lang=pl";
            
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            string response = await client.GetStringAsync(URL);

            var data = JsonConvert.DeserializeObject<ThematicAreas[]>(response);

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //await GetDataFromApi();
        }
    }
}
