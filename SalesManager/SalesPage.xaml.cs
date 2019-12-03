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
using SalesManager.Model;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SalesManager
{
    /// <summary>
    /// Interaction logic for SalesPage.xaml
    /// </summary>
    public partial class SalesPage : Page
    {
        //Holds the cart
        ObservableCollection<Product> sale=new ObservableCollection<Product>();
        //Holds the sales made
        ObservableCollection<Sales> mysales = new ObservableCollection<Sales>();
        ObservableCollection<Product> myproducts;

        IFormatter serializer;
        NavigationService nav;
        decimal total;

        public SalesPage()
        {
            InitializeComponent();
        }

        private void signout_btn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LogIn());
            this.ShowsNavigationUI = false;
           
        }

        private void product_searchtxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //Eventhanler for text change in the quantity textbox
        private void quantity_txtblk_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if not empty mutiply to find the total and save in the total text block
            if (quantity_txtblk.Text!="")
            {
                total_txtblk.Text = (decimal.Parse(quantity_txtblk.Text) * decimal.Parse(price_txtblk.Text)).ToString() ;
            }
            
        }

        //Handles the click event on the pay button
        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            //defines a sales object to hold our current sale
            Sales mysale = new Sales();
            mysale.Products = sale;
            
            mysale.Amount = total;
            mysale.Balance = 0;
            mysale.Paid = true;
            //then adds to the sales collection
            mysales.Add(mysale);

            //This should be done in the backgroun
            FileStream userfile = new FileStream("Sales.lf", FileMode.Create, FileAccess.ReadWrite);
            //saves the current sales status 
            serializer.Serialize(userfile, mysales);
            userfile.Close();

            FileStream userfile2 = new FileStream("Inventory.lf", FileMode.Open, FileAccess.ReadWrite);
            //saves the current inventory status
            serializer.Serialize(userfile2, myproducts);
            userfile2.Close();
            //clears the chart for new sales
            sale.Clear();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            //Creates a new product instance
            Product n_pr = new Product();  
            //gets the quatity of product sold
            var quant_sold = ((Product)product_grid.DataContext).Quantity;
            //gets the amount in stock
            var in_stock = ((Product)product_grid.DataContext).Amt_Instock;
            //sets the new number in stock after the sale
            amt_stk_txtblk.Text = (in_stock - quant_sold).ToString();

            //jagons that mean cloning of the object
            n_pr.Name = ((Product)product_grid.DataContext).Name;
            n_pr.Price = ((Product)product_grid.DataContext).Price;
            n_pr.Quantity = ((Product)product_grid.DataContext).Quantity;
            n_pr.Tax = ((Product)product_grid.DataContext).Tax;
            n_pr.TotalPrice = ((Product)product_grid.DataContext).TotalPrice;
            n_pr.Description = ((Product)product_grid.DataContext).Description;
            n_pr.Category = ((Product)product_grid.DataContext).Category;
            n_pr.Amt_Instock = ((Product)product_grid.DataContext).Amt_Instock;

            //add to cart
            sale.Add(n_pr);
            //The total amount of goods in the cart
            total = sale.Sum(item => item.TotalPrice);
            whole_total_txtblk.Text = total.ToString();
            //set it to zero
            quantity_txtblk.Text = "0";
            total_txtblk.Text = "0";
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //set cart to sale object
            cart.ItemsSource = sale;

            serializer = new BinaryFormatter();

            if (File.Exists("Sales.lf"))
            {
                FileStream userfile = new FileStream("Sales.lf", FileMode.Open, FileAccess.Read);
                mysales = serializer.Deserialize(userfile) as ObservableCollection<Sales>;
                userfile.Close();

                FileStream userfile2 = new FileStream("Inventory.lf", FileMode.Open, FileAccess.Read);
                myproducts = serializer.Deserialize(userfile2) as ObservableCollection<Product>;
                userfile.Close();
            }
            else
            {
                FileStream userfile = new FileStream("Sales.lf", FileMode.Create, FileAccess.ReadWrite);
                mysales = new ObservableCollection<Sales>
                { 
                    new Sales{ 
                     Products= new ObservableCollection<Product>{
                            new Product{Name="Futa bread",Description="A university baked bread",Price=50,Category="Bread",Amt_Instock=50}
                     },Amount=50,Balance=0,Paid=true

                    }
                    
                   
                };

                serializer.Serialize(userfile, mysales);
                userfile.Close();

            }
            //set items in the product list
            product_list.ItemsSource = myproducts;
            
        }
    }
}
