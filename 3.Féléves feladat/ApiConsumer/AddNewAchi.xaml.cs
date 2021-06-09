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
    /// Interaction logic for AddNewAchi.xaml
    /// </summary>
    public partial class AddNewAchi : Window
    {
        string gameId;
        Game game1;
        string token;

        public AddNewAchi()
        {
            InitializeComponent();
        }

        public AddNewAchi(Game game , string token)
        {
            this.token = token;
            this.gameId = game.GameId;
            game1 = game;
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            
            Achievement a = new Achievement() { GameId = gameId, Name = nameInput.Text.ToString()};

            if (goldcheck.IsChecked == true)
            {
                a.achiLevel = AchiLevel.gold;
            }
            else if (silvercheck.IsChecked == true)
            {
                a.achiLevel = AchiLevel.silver;
            }
            else
            {
                a.achiLevel = AchiLevel.bronze;
            }

            RestService restservice = new RestService("https://androidfelevesendpoints.azurewebsites.net/", "/Achi");
            restservice.Post<Achievement>(a);


            AchiWindow aw = new AchiWindow(game1 , token);
            aw.Show();
            aw.Close();
            this.Close();

            aw = new AchiWindow(game1 , token);
            aw.Show();
            
        }
    }
}
