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
using WhatsAppApi.Register;
using WhatsAppApi;
using WhatsAppApi.Response;


namespace SalesManager
{
    /// <summary>
    /// Interaction logic for whatsappdemo.xaml
    /// </summary>
    public partial class whatsappdemo : Page
    {
        public whatsappdemo()
        {
            InitializeComponent();
        }

        string password1;
        string error;
        private void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            password1 = WhatsAppApi.Register.WhatsRegisterV2.RegisterCode(phone.Text, comfirmation.Text,out error);
            if (string.IsNullOrEmpty(password1))
            {
                MessageBox.Show(error);
            }
        }

        private void request_btn_Click(object sender, RoutedEventArgs e)
        {
            if (WhatsAppApi.Register.WhatsRegisterV2.RequestCode(phone.Text, out password1, out error))
            {
                if (string.IsNullOrEmpty(password1))
                {
                    request_btn.IsEnabled = false;
                    confirm_btn.IsEnabled = true;
                }
                MessageBox.Show(error);
            }
            else
            {
                MessageBox.Show(error);
            }
        }
    }
}
