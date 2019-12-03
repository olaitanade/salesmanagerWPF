using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for chartexample2.xaml
    /// </summary>
    public partial class chartexample2 : Page
    {
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        NavigationService nav;

        public chartexample2()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LineSeries ls = new LineSeries()
            {
                Values = new ChartValues<double> { 20, 25, 30 },
                DataLabels = true,
                LabelPoint = point => point.X + " remaining"
            };

            //Labels for the chart x axis
            Labels = new[]
            {
                "Waw",
                "Futa bread",
                "Ariel"
            };

            //Formatter for the chart y axis
            Formatter = value => value + " items";

            cartesian_chart.Series[0].Values = new ChartValues<double> { 20, 25, 30 };
            cartesian_chart.Series[0].LabelPoint = point => point.X + " remaining";
            cartesian_chart.Series[1].Values = new ChartValues<double> { 25, 15, 41 };
            cartesian_chart.Series[1].LabelPoint = point => point.X + "sold";

            
            
        }

        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new chartexample3());
            this.ShowsNavigationUI = false;
        }

    }
}
