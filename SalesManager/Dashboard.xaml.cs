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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Actions;
using MaterialDesignColors;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MahApps.Metro.Native;
using MaterialDesignColors;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;


namespace SalesManager
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        NavigationService nav;
        
        public Dashboard()
        {
            InitializeComponent();
        }

        //Eventhandler for the inventory button, Note:Temporary exist for now
        private void inventory_btn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Inventory());
            this.ShowsNavigationUI = false;
            
        }

        //Eventhandler for the sales button
        private void salesmade_btn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new SalesPage());
            this.ShowsNavigationUI = false;
        }

        //Eventhandler for the account button
        //private void account_btn_Click(object sender, RoutedEventArgs e)
        //{
        //    nav = NavigationService.GetNavigationService(this);
        //    nav.Navigate(new Accounts());
        //    this.ShowsNavigationUI = false;   
        //}

        private void chart_btn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new chartExample());
            this.ShowsNavigationUI = false;
        }
    }
}
