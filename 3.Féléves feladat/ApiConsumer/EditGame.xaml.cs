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
    /// Interaction logic for EditGame.xaml
    /// </summary>
    public partial class EditGame : Window
    {
        string token;
        Game game;
        public EditGame(string token , Game game)
        {
            InitializeComponent();
            this.token = token;
            this.game = game;
            nameInput.Text = game.Name;
            genreInput.Text = game.Genre;
            gameTimeInput.Text = game.GameTime.ToString();



        }

        
        

        private void Edit(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService("https://androidfelevesendpoints.azurewebsites.net/", "/Game", token);

            Game g = new Game() { GameTime = int.Parse(gameTimeInput.Text), Genre = genreInput.Text.ToString() , Name = nameInput.Text };
            g.UserId = game.UserId;
            g.GameId = game.GameId;
           
            g.Achievements = game.Achievements;
            restservice.Put<string, Game>(g.GameId, g);


            GamesWindow uw = new GamesWindow(game.UserId,token);
            uw.Show();
            this.Close();
        }
    }
}
