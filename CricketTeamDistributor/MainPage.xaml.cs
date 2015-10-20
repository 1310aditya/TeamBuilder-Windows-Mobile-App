using Newtonsoft.Json;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace CricketTeamDistributor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            //List<int> a = new List<int>();
            //a.Add(1);
            //a.Add(2);
            //a.Add(3);
            //a.Add(4);
            //a.Add(5);
            //a.Add(6);
            //a.Add(7);
            //string x = JsonConvert.SerializeObject(a);
            //List<int> b = JsonConvert.DeserializeObject<List<int>>(x);
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            datamodel temp = new datamodel();

            temp.src = "Assets/cricket-hd-wallpapers.jpg";
            temp.title = "Cricket";
            CricketButton.DataContext = temp;
            
            temp = new datamodel();
            temp.src = "Assets/real-madrid-granada.jpg";
            temp.title = "Football";
            Football.DataContext = temp;
                        
        }

        
        private void CricketButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page2), "Cricket");
        }

        private void Football_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page2), "Football");
        }
    }
}
