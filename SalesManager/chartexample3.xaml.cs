using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.Configurations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SalesManager
{
    /// <summary>
    /// Interaction logic for chartexample3.xaml
    /// </summary>
    public partial class chartexample3 : Page
    {
        ObservableCollection<City> Db;
        public ChartValues<City> Results { get; set; }
        public ObservableCollection<string> Labels { get; set; }
        public Func<double, string> MillionFormatter { get; set; }
        NavigationService nav;

        public object Mapper { get; set; }

        public chartexample3()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Db = new ObservableCollection<City>
            {
                new City{Name="Lagos",Population=2000000,Country="Nigeria"},
                new City{Name="Portharcourt",Population=2500000,Country="Nigeria"},
                new City{Name="Akure",Population=1500000,Country="Nigeria"},
                new City{Name="London",Population=3000000,Country="England"},
                new City{Name="Accra",Population=2300000,Country="Ghana"},
                new City{Name="Abuja",Population=1300000,Country="Nigeria"},
                new City{Name="Paris",Population=4000000,Country="France"},
                new City{Name="Rome",Population=3600000,Country="Italy"}
            };

            //lets configure the chart to plot cities
            Mapper = Mappers.Xy<City>()
                .X((city, index) => index)
                .Y(city => city.Population);

            //lets take the first 15 records by default;
            var records = Db.OrderByDescending(x => x.Population).Take(15).ToArray();

            Results = records.AsChartValues();
            Labels = new ObservableCollection<string>(records.Select(x => x.Name));

            MillionFormatter = value => (value / 1000000).ToString("N") + "M";

            DataContext = this;
        }

        private void product_searchtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            var q = (product_searchtxt.Text ?? string.Empty).ToUpper();

            var records = Db
               .Where(x => x.Name.ToUpper().Contains(q) || x.Country.ToUpper().Contains(q))
               .OrderByDescending(x => x.Population)
               .Take(15)
               .ToArray();

            Results.Clear();
            Results.AddRange(records);

            Labels.Clear();
            foreach (var record in records) Labels.Add(record.Name);
        }

        private void next_btn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new chartexample4());
            this.ShowsNavigationUI = false;
        }
    }

    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }
        public double Area { get; set; }
        public string Country { get; set; }
    }
}
