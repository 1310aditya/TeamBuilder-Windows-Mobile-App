using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        private void BuildButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BuildTeam),GameTextBlock.Text);
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyTeam),GameTextBlock.Text);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddTeam),GameTextBlock.Text);
        }
    }
}
