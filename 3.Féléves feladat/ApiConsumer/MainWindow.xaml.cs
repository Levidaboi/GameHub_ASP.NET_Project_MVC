using Models;
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

namespace ApiConsumer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string token;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Login(object sender, RoutedEventArgs e)
        {

            RestService restservice = new RestService("https://androidfelevesendpoints.azurewebsites.net/", "/Auth");
           // RestService restservice = new RestService("https://localhost:5001/", "/Auth");
            TokenViewModel tvm = await restservice.Put<TokenViewModel, LoginViewModel>(new LoginViewModel()
            {
                Username = nameInput.Text,
                Password = passwordInput.Text
            });
            token = tvm.Token;


            if (token != null)
            {
                Users u = new Users(token);
                u.Show();
                this.Close();
            }

           
        }

        
    }
}
