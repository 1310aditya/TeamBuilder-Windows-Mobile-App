using CricketTeamDistributor.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace CricketTeamDistributor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyTeam : Page
    {
        static string Game = "";
        public List<Player> Team = new List<Player>();
        public List<Player> SelectedList = new List<Player>();
        public MyTeam()
        {
            this.InitializeComponent();
            Loaded += MyTeam_Loaded;
        }

        async void MyTeam_Loaded(object sender, RoutedEventArgs e)
        {
            View();
         }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Game = e.Parameter.ToString();
            if (Game == "Cricket")
            {
                FirstAttBox.Text = "Batting";
                SecondAttBox.Text = "Bowling";
            }
            else
            {
                FirstAttBox.Text = "Attack";
                SecondAttBox.Text = "Defence";
            
            }
        }

        public List<Player> PlayersModel
        {
            get { return Team; }
        }
        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddTeam),Game);
        }

        private void BuildTeamButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BuildTeam),Game);
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            List<Player> OldList = await PlayerFile.ViewMyPlayers(Game);
            ObtainSelectedItems();
            List<Player> ToDelList = SelectedList;
            
            if (ToDelList.Count == 0)
            {
                MessageDialog msgbox = new MessageDialog("Select Player to be deleted!");
                await msgbox.ShowAsync(); 
                await PlayerFile.AddToFile(OldList,Game);
                View();
            }
            else
            {

                for (int i = 0; i < ToDelList.Count; i++)
                {
                    for (int j = 0; j < OldList.Count; j++)
                    {
                        if (Helper(ToDelList, OldList, i, j))
                        {
                            OldList.RemoveAt(j);
                        }

                    }
                }

                await PlayerFile.AddToFile(OldList, Game);
                View();
            }
        }

        public bool Helper(List<Player> a, List<Player> b,int i, int j)
        {
            if (a[i].Name==b[j].Name&&a[i].FirstAtt==b[j].FirstAtt&&a[i].SecondAtt==b[j].SecondAtt)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private async void View()
        {   
            try
            {
                List<Player> _PlayersModel = await PlayerFile.ViewMyPlayers(Game);
                Team = _PlayersModel;
                TeamView.DataContext = PlayersModel;
 
            }
            catch (FileNotFoundException)
            {
                Frame.Navigate(typeof(AddTeam), Game);
            }
        }

        private void ObtainSelectedItems()
        {
            SelectedList = TeamView.SelectedItems.OfType<Player>().ToList();
        }
        
    }
}
