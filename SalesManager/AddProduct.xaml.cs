using SalesManager.DummyDataStruc;
using SalesManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        ObservableCollection<Product> myproducts;
        Product pr = new Product();
        IFormatter serializer;
        NavigationService nav;
        public AddProduct()
        {
            InitializeComponent();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            myproducts.Add(pr);

            FileStream userfile = new FileStream("Inventory.lf", FileMode.Create, FileAccess.ReadWrite);
            serializer.Serialize(userfile, myproducts);
            MessageBox.Show(myproducts[0].Name);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myproducts = ProductStorage.Instance;
            product_grid.DataContext = pr;

            //get serializer
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

           
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Inventory());
            this.ShowsNavigationUI = false;
        }
    }
}
