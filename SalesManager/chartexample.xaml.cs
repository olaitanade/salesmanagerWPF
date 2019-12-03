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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace SalesManager
{
    /// <summary>
    /// Interaction logic for chartExample.xaml
    /// </summary>
    public partial class chartExample : Page
    {
        LiveCharts.SeriesCollection series;
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        NavigationService nav;

        public chartExample()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //ColumnSeries chart object
            ColumnSeries col = new ColumnSeries()
             {
                 //Holds the Y coordinates of the chart
                 Values = new ChartValues<double> { 20, 25, 30 },
                 //define the labels for the bars in the chart
                 DataLabels = true,
                 LabelPoint = point => point.Y + " remaining"
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

            //Defining x and y axis
            //for x axis
            Axis ax = new Axis() { Separator = new LiveCharts.Wpf.Separator() { Step = 1, IsEnabled = false } };
            ax.Labels = Labels;
            //for y axis
            Axis ax_y = new Axis()
            {
                Separator = new LiveCharts.Wpf.Separator(),
                LabelFormatter = Formatter
            };

            //Add to the column cartesian chart
            cartesian_chart.Series.Add(col);
            cartesian_chart.AxisX.Add(ax);
            cartesian_chart.AxisY.Add(ax_y);

            
            

            
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartPoint)
        {

        }

        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new chartexample2());
            this.ShowsNavigationUI = false;
        }
    }
}
