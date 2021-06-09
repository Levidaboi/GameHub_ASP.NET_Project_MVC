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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        string token;
        User u;
        public EditUser(string token , User u)
        {
            InitializeComponent();
            this.token = token;
            this.u = u;
            ageInput.Text = u.Age.ToString();
            nameInput.Text = u.Name;


        }

        private  void Edit(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService("https://androidfelevesendpoints.azurewebsites.net/", "/User" , token);

            User us = new User() { Age = int.Parse(ageInput.Text) , Name = nameInput.Text.ToString() };
            us.UserId = u.UserId;
            us.GameLibrary = u.GameLibrary;
            restservice.Put<string,User>(u.UserId, us);


            Users uw = new Users(token);
            uw.Show();
            this.Close();


        }
    }
}
