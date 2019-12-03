using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    /// Interaction logic for rowseries.xaml
    /// </summary>
    public partial class rowseries : UserControl
    {
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public rowseries()
        {
            InitializeComponent();


            RowSeries row = new RowSeries()
            {
                //Holds the X coordinates of the chart
                Values = new ChartValues<double> { 20, 25, 30 },
                //define the labels for the bars in the chart
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


            //Add to the row cartesiam chart
            cartesian_chart1.Series.Add(row);
            cartesian_chart1.AxisX.Add(ax_y);//because this is inverted,i.e row chart
            cartesian_chart1.AxisY.Add(ax);
        }
    }
}
