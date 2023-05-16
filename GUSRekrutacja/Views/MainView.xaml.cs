using GUSRekrutacja.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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

namespace GUSRekrutacja.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            InitAsync();
        }
        private async void InitAsync()
        {
            ObservableCollection<ThematicArea> ThematicAreaList = await GetDataFromApi();

            TestDataGrid.ItemsSource = ThematicAreaList;
        }

        private static async Task<ObservableCollection<ThematicArea>> GetDataFromApi()
        {
            const string URL = @"https://api-dbw.stat.gov.pl/api/1.1.0/area/area-area?lang=pl";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            string response = await client.GetStringAsync(URL);

            return JsonConvert.DeserializeObject<ObservableCollection<ThematicArea>>(response);
        }
    }
}
