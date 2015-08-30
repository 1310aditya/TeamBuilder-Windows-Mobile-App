using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
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
    public sealed partial class AddNotif : Page
    {
        string Game = "";
        public AddNotif()
        {
            HardwareButtons.BackPressed += OnBackPressed;
            this.InitializeComponent();
        }

        private async void OnBackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            MessageDialog msgbox = new MessageDialog("Choose one of the options below:");
            await msgbox.ShowAsync(); 
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Game = e.Parameter.ToString();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddTeam),Game);
        }

        private void ViewTeamButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyTeam),Game);
        }
    }
}
