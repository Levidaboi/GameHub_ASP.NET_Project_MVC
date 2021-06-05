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
    /// Interaction logic for GamesWindow.xaml
    /// </summary>
    public partial class GamesWindow : Window
    {
        string userId;

        public GamesWindow( User u)
        {
            //itt lehet hiba
            InitializeComponent();
            this.userId = u.UserId;
            GetPlayListNames(userId);
        }
        public GamesWindow(string uid)
        {
            
            InitializeComponent();
            this.userId = uid;
            GetPlayListNames(uid);
        }


        public async Task GetPlayListNames(string userid)
        {
            gameGrid.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", "/User");
            User playlistnames = await restservice.Get<User,string>(userid);

            gameGrid.ItemsSource = playlistnames.GameLibrary;

            restservice = new RestService("https://localhost:5001/", "/User");
            playlistnames = await restservice.Get<User, string>(userid);

            gameGrid.ItemsSource = playlistnames.GameLibrary; 
            gameGrid.SelectedIndex = 0;
        }

        public async Task GetPlayListNames()
        {
            gameGrid.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", $"/User");
            User playlistnames = new User();

            gameGrid.ItemsSource = playlistnames.GameLibrary;
            gameGrid.SelectedIndex = 0;
        }
        public GamesWindow()
        {

            InitializeComponent();
            GetPlayListNames();
        }

        private async void DeleteGame(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService("https://localhost:5001/", "/Game");
            restservice.Delete<string>((gameGrid.SelectedItem as Game).GameId);


            //gameGrid.ItemsSource = null;
            GetPlayListNames(userId);
            

        }

        private void BackBtn(object sender, RoutedEventArgs e)
        {
            Users uw = new Users();
            uw.Show();
            this.Close();


        }

        private void AddnewGame(object sender, RoutedEventArgs e)
        {
            NewGameAdd ang = new NewGameAdd(userId);
            ang.Show();
            this.Close();
            
        }

        private void ListAchievements(object sender, RoutedEventArgs e)
        {
            AchiWindow aw = new AchiWindow(gameGrid.SelectedItem as Game);
            aw.Show();
            this.Close();
        }
    }
}
