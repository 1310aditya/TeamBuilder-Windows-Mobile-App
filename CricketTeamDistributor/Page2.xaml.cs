using CricketTeamDistributor.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        protected void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GameTextBlock.Text = e.Parameter.ToString();

            if (GameTextBlock.Text == "Cricket")
            {
                datamodel temp = new datamodel();

                temp.src = "Assets/addcricketplayer.jpg";
                temp.title = "Add Player";
                AddButton.DataContext = temp;

                temp = new datamodel();
                temp.src = "Assets/buildcricketteam.jpg";
                temp.title = "Build Team";
                BuildButton.DataContext = temp;

                temp = new datamodel();
                temp.src = "Assets/Indian_cricket_team_with_cup.jpg";
                temp.title = "My Team";
                ViewButton.DataContext = temp;
            }

            else
            {

                datamodel temp = new datamodel();

                temp.src = "Assets/062814-World-Cup-Colombia-James-Rodriguez-PI-CH.vadapt.620.high.0.jpg";
                temp.title = "Add Team";
                AddButton.DataContext = temp;

                temp = new datamodel();
                temp.src = "Assets/1407940249936_wps_1_Real_Madrid_team_players_.jpg";
                temp.title = "Build Team";
                BuildButton.DataContext = temp;

                temp = new datamodel();
                temp.src = "Assets/full-view-and-download-real-madrid-team-wallpaper-sport-images-real-madrid-squad-hd-wallpapers-team-633558272.jpg";
                temp.title = "My Team";
                ViewButton.DataContext = temp;
            }
            
        }

        private async void BuildButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyClass.SelectedList = await PlayerFile.ViewMyPlayers(GameTextBlock.Text);
                if (MyClass.SelectedList.Count > 5)
                {
                    Frame.Navigate(typeof(BuildTeam), GameTextBlock.Text);
                }
            }
            catch (Exception)
            {
                MessageDialog NoTeamMsg = new MessageDialog(" No Players added or total players less than 5!");
                NoTeamMsg.ShowAsync();
            }
            
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyTeam),GameTextBlock.Text);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddTeam),GameTextBlock.Text);
        }

        private async void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msgbox = new MessageDialog("Welcome to the Team Builder!\n\n" +
            "Ever went to the field and had to undergo the hassle of dividing teams for cricket or football?" +
            "Ended up fighting amongst friends? The Team Builder stores your friends' and your attributes." +
            " All you have to do is select the players in the game today and 'Build'!\n\n Voila ! You have 2 competitive teams" +
            " ready to go.\n\nKindly Build MORE THAN 5 Players!\n\nInstructions:\n\n1.To add a Player to Your list of player use 'Add Player'.\n\n 2. To View existing players in list use and selecting players for building team " +
            "'My Team'\n\n3.To Build Your teams for the game, choose 'Build Team' to build 2 teams out of all the players in the list.");

            await msgbox.ShowAsync();

        }
    }
}
