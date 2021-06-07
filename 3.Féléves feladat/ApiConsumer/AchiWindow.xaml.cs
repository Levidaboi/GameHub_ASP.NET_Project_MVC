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
    /// Interaction logic for AchiWindow.xaml
    /// </summary>
    public partial class AchiWindow : Window
    {
        Game g;
        public AchiWindow()
        {
            InitializeComponent();
        }

        public AchiWindow(Game g)
        {
            this.g = g;
            InitializeComponent();
            GetPlayListNames();
        }

        public async Task GetPlayListNames()
        {
            AchiGrid.ItemsSource = null;
            RestService restservice = new RestService("https://androidfelevesendpoints.azurewebsites.net/", "/Achi");
            List<Achievement> playlistnames = await restservice.Get<Achievement>();

            List<Achievement> a = new List<Achievement>();
            foreach (var item in playlistnames)
            {
                if (item.GameId == g.GameId)
                {
                    a.Add(item);
                }
            }



            AchiGrid.ItemsSource = a;
           
            AchiGrid.SelectedIndex = 0;
        }

        private void AddNewAchi(object sender, RoutedEventArgs e)
        {
            AddNewAchi ana = new AddNewAchi(g);
            ana.Show();
            this.Close();
        }

        private void DeleteAchi(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService("https://androidfelevesendpoints.azurewebsites.net/", "/Achi");
            restservice.Delete<string>((AchiGrid.SelectedItem as Achievement).AchiId);

            GetPlayListNames();
        }

        private void Backbtn(object sender, RoutedEventArgs e)
        {
            GamesWindow gw = new GamesWindow(g.UserId);
            gw.Show();
            this.Close();
        }
    }
}
