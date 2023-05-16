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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitAsync();
        }

        private async void InitAsync()
        {
            ThematicAreas[] testArray = await GetDataFromApi();

            DataList.ItemsSource = testArray;
            //await GenerateDataGrid();
        }

        //private async Task GenerateDataGrid()
        //{
        //    if (DataList.ItemsSource == null || DataList.Items.Count == 0)
        //        return;

        //    foreach (var property in DataList.Items[0].GetType().GetProperties())
        //    {
        //        var column = new GridViewColumn();
        //        column.Header = property.Name;
        //        column.DisplayMemberBinding = new Binding(property.Name);

        //        MainGridView.Columns.Add(column);
        //    }

        //    //DataList.View = gridView;
        //}

        private static async Task<ThematicAreas[]> GetDataFromApi()
        {
            const string URL = @"https://api-dbw.stat.gov.pl/api/1.1.0/area/area-area?lang=pl";
            
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            string response = await client.GetStringAsync(URL);

            return JsonConvert.DeserializeObject<ThematicAreas[]>(response);
        }

    }
}
