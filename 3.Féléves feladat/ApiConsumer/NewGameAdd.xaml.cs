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
    /// Interaction logic for NewGameAdd.xaml
    /// </summary>
    public partial class NewGameAdd : Window
    {
        string userId;

        public NewGameAdd()
        {
            InitializeComponent();
        }

        public NewGameAdd(string userid)
        {
            userId = userid;
            InitializeComponent();
        }

        private  void AddGame(object sender, RoutedEventArgs e)
        {
            Game g = new Game() { Name = nameInput.Text.ToString() , Genre = genreInput.Text.ToString(), Rating = int.Parse(ratingInput.Text) , GameTime = int.Parse(gameTimeInput.Text) , UserId = userId.ToString() };

            RestService restservice = new RestService("https://androidfelevesendpoints.azurewebsites.net/", "/Game");
            restservice.Post<Game>(g);

            GamesWindow gw = new GamesWindow(userId);
            gw.Show();            
            this.Close();
        }

        private void Backbtn(object sender, RoutedEventArgs e)
        {
            GamesWindow gw = new GamesWindow(userId);
            gw.Show();
            this.Close();
        }
    }
}
