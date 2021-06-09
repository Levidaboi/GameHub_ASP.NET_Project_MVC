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
using System.Windows.Shapes;

namespace ApiConsumer
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        string token;
        public AddUserWindow(string token)
        {
            this.token = token;
            InitializeComponent();
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            User u = new User() {Age = int.Parse (ageInput.Text.ToString()),UserId = Guid.NewGuid().ToString(), Name = userNameInput.Text.ToString() };




            RestService restservice = new RestService("https://androidfelevesendpoints.azurewebsites.net/", "/User", token);
            restservice.Post<User>(u);


            Users uw = new Users(token);
            uw.Show();
            this.Close();
        }
    }
}
