using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Actions;
using MaterialDesignColors;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MahApps.Metro.Native;
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
    /// Interaction logic for MainWindow.xaml
    /// This is the main window for the software. It controls the navigation of pages in the software
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //this.ShowMessageAsync("Son", "Romans 8:32",MessageDialogStyle.Affirmative);
        }
    }
}
