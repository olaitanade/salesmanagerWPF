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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Actions;
using MaterialDesignColors;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MahApps.Metro.Native;
using System.Threading;


namespace SalesManager
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// This is the login page that contols the signing in of user both Admin/Worker.
    /// If Admin,it directs to the dashboard for monitoring and management
    /// If Worker,it directs to the sales page where sales are handled.
    /// </summary>
    public partial class LogIn : Page
    {
        //Holds the dummy user data available
        ObservableCollection<Users> myusers;
        //Controls the navigation of this page to other pages
        NavigationService nav;

        //Fetch the required data for the page
        Thread th;
        public LogIn()
        {
            InitializeComponent();
        }

        //eventhandler for the login button click
        private  void logIn_btn_Click(object sender, RoutedEventArgs e)
        {


            MainWindow mw = (MainWindow)Window.GetWindow(this);
            mw.ShowMessageAsync("hello", "hello");


            //Query the dummy data for user info, if registerd or not
            var getuser = from n in myusers
                          where n.Name == username.Text && n.Password == password.Password
                          select n;

            foreach (Users n in getuser)
            {
                if (n.Rights == "Admin")
                {
                    nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new Dashboard());
                    this.ShowsNavigationUI = false;
                }
                else if (n.Rights == "Worker")
                {
                    nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new SalesPage());
                    this.ShowsNavigationUI = false;
                }
                else
                {
                    MessageBox.Show("Your details are incorrect, see the administrator.", "Not Registered");
                }
            }
            

            
        }

        //On loading the page
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //get serializer
            IFormatter serializer = new BinaryFormatter();
            //Check if file has been created
            if (File.Exists("Users.lf"))
            {
                //Open for reading since it has been created
                FileStream userfile = new FileStream("Users.lf", FileMode.Open, FileAccess.Read);
                //Deserialize the user dummy data
                myusers = serializer.Deserialize(userfile) as ObservableCollection<Users>;
                userfile.Close();
            }
            else
            {
                FileStream userfile = new FileStream("Users.lf", FileMode.Create, FileAccess.ReadWrite);
                myusers = new ObservableCollection<Users>
                { 
                    new Users{Name="Admin",Password="admin",Rights="Admin"},
                    new Users{Name="Worker",Password="worker",Rights="worker"}
                };

                serializer.Serialize(userfile, myusers);
                userfile.Close();
            }
        }

      
    }
}
