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
using System.Collections.ObjectModel;
using SalesManager.Model;
using System.Runtime.Serialization;
using SalesManager.DummyDataStruc;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SalesManager
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Page
    {
        //Collection of products the store sells,could have finished or still remains,anyhow its shows all
        ObservableCollection<Product> myproducts;
        //Holds just one 
        Product pr = new Product();
        //serialize data to a file
        IFormatter serializer;
        //navigation service
        NavigationService nav;

        public Inventory()
        {
            InitializeComponent();
        }

        private void amtinstk_txtblk_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void product_searchtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Use linq query to fetch
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AddProduct());
            this.ShowsNavigationUI = false;
        }

        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            myproducts.Remove((Product)product_list.SelectedItem);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            amtinstk_txtblk.IsEnabled = true;
            edt_btn.IsEnabled = false;
            edt_btn.Visibility = Visibility.Hidden;
            save_btn.IsEnabled = true;
            save_btn.Visibility = Visibility.Visible;
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            amtinstk_txtblk.IsEnabled = false;

            edt_btn.IsEnabled = true;
            edt_btn.Visibility = Visibility.Visible;
            save_btn.IsEnabled = false;
            save_btn.Visibility = Visibility.Hidden;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Holds the reference to a singleton
            myproducts = ProductStorage.Instance;
            //A serializer
            serializer = new BinaryFormatter();

            if (File.Exists("Inventory.lf"))
            {
                FileStream userfile = new FileStream("Inventory.lf", FileMode.Open, FileAccess.Read);
                myproducts = serializer.Deserialize(userfile) as ObservableCollection<Product>;
                userfile.Close();
            }
            else
            {
                FileStream userfile = new FileStream("Inventory.lf", FileMode.Create, FileAccess.ReadWrite);
                myproducts = new ObservableCollection<Product>
                { 
                    new Product{Name="Futa bread",Description="A university baked bread",Price=50,Category="Bread",Amt_Instock=50}
                   
                };

                serializer.Serialize(userfile, myproducts);
                userfile.Close();

            }

            //Send to the product list for display
            product_list.ItemsSource = myproducts;
        }

        //navigate back
        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Dashboard());
            this.ShowsNavigationUI = false;
        }
    }
}
