using CricketTeamDistributor.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class AddTeam : Page
    {   
        string Game = "";
        public AddTeam()
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
            string Game = e.Parameter.ToString();

            if (Game == "Cricket")
            {
                FirstSkillBox.Text = "Batting";
                SecondSkillBox.Text = "Bowling";
            }
            else
            {
                FirstSkillBox.Text = "Attack";
                SecondSkillBox.Text = "Defence";
            }
        }

        private void AddtoDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstSkillBox.Text == "Batting" )
            {
                Game = "Cricket";
                AddPlayerCric(NameTextBox.Text, int.Parse(FirstAttBox.Text), int.Parse(SecondAttBox.Text));
            }
            else
            {
                Game="Football";
                AddPlayerFoot(NameTextBox.Text,int.Parse(FirstAttBox.Text), int.Parse(SecondAttBox.Text));
            }
            Frame.Navigate(typeof(AddNotif),Game);
        }

        private async void AddPlayerCric(string a,int b,int c)
        {
            var newTeam = new List<Player>();
            try
            {
                newTeam = await PlayerFile.ViewMyPlayers("Cricket");
                newTeam.Add(new Player() { Name = a, FirstAtt = b, SecondAtt = c });
            }
            catch (FileNotFoundException)
            {
                newTeam.Add(new Player() { Name = a, FirstAtt = b, SecondAtt = c });
            }
            await PlayerFile.AddToFile(newTeam, "Cricket");    
        }

       private async void AddPlayerFoot(string a,int b,int c)
        {
            var newTeam = new List<Player>();

            try
            {
                newTeam = await PlayerFile.ViewMyPlayers("Football");
                newTeam.Add(new Player() { Name = a, FirstAtt = b, SecondAtt = c });
            }
            catch (FileNotFoundException)
            {
                newTeam.Add(new Player() { Name = a, FirstAtt = b, SecondAtt = c });
            } 
           await PlayerFile.AddToFile(newTeam, "Football");    
        }

       private async void FirstAttBox_LostFocus(object sender, RoutedEventArgs e)
       {
           if (int.Parse(FirstAttBox.Text) > 5)
           {
               FirstAttBox.Text = "";   
           }
           MessageDialog msgbox = new MessageDialog("Rate out of 5!");
           await msgbox.ShowAsync();
           
       }

       private async void SecondAttBox_LostFocus(object sender, RoutedEventArgs e)
       {
           if (int.Parse(SecondAttBox.Text) > 5)
           {
               SecondAttBox.Text = "";
           }
           MessageDialog msgbox = new MessageDialog("Rate out of 5!");
           await msgbox.ShowAsync();
       }

       private async void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
       {
           List<Player> PlayerList = await PlayerFile.ViewMyPlayers(Game);
           foreach (var player in PlayerList)
           {
               if (player.Name.ToLower() == NameTextBox.Text.ToLower())
               {
                   MessageDialog msgbox = new MessageDialog("Player Already Exists!");
                   await msgbox.ShowAsync();
                   NameTextBox.Text = "";
                   break;
               }
           }
       }
    }
}
