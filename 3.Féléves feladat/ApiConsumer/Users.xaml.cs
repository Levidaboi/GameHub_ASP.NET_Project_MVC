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
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
            GetPlayListNames();
        }

        public async Task GetPlayListNames()
        {
            UsersGrid.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", "/User");
            IEnumerable<User> playlistnames =
                await restservice.Get<User>();

            UsersGrid.ItemsSource = playlistnames;
            UsersGrid.SelectedIndex = 0;
        }

        private async void DeleteUser(object sender, RoutedEventArgs e)
        {
            
            RestService restservice = new RestService("https://localhost:5001/", "/User");
            restservice.Delete<string>((UsersGrid.SelectedItem as User).UserId);


            UsersGrid.ItemsSource = null;

            RestService restservice2 = new RestService("https://localhost:5001/", "/User");
            IEnumerable<User> playlistnames =
                await restservice2.Get<User>();

            UsersGrid.ItemsSource = playlistnames;
            UsersGrid.SelectedIndex = 0;
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            AddUserWindow auw = new AddUserWindow();
            auw.Show();
            this.Close();
        }

        private void ListUsersGames(object sender, RoutedEventArgs e)
        {
            GamesWindow gw = new GamesWindow(UsersGrid.SelectedItem as User);
            gw.Show();
            this.Close();
        }
    }
}
