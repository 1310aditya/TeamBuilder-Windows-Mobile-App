using CricketTeamDistributor.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
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
    public sealed partial class BuildTeam : Page
    {
        string Game = "";
        public List<Player> TeamOne = new List<Player>();
        public List<Player> TeamTwo = new List<Player>();
        public BuildTeam()
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
            Game = e.Parameter.ToString();
            BuildMethod();
        }

        private void RebuildButton_Click(object sender, RoutedEventArgs e)
        {
            TeamOne = new List<Player>();
            TeamTwo = new List<Player>();
            BuildMethod();
        }

        public List<Player> PlayersModelTeamOne
        {
            get { return TeamOne; }
        }

        public List<Player> PlayersModelTeamTwo
        {
            get { return TeamTwo; }
        }

        private async void BuildMethod()
        {
            //TeamBuilding Algorithm

            //Correct this. Take selected items from where Build Button is entered.

            List<Player> BuildList = await PlayerFile.ViewMyPlayers(Game);
            //

            if (CheckEven(BuildList.Count))
            {
                //EvenPlayersAlgorithm
                int[] TotalRating = new int[BuildList.Count];

                for (int i = 0; i < BuildList.Count; i++)
                {
                    TotalRating[i] = BuildList[i].FirstAtt + BuildList[i].SecondAtt;
                }

                int RatingsForTeams = TotalRating.Sum();
                int RatingTeamA;

                RatingTeamA = RatingsForTeams / 2;

                int PlayersPerTeam = BuildList.Count / 2;

                Random r = new Random();

                int[] PermuteArray = new int[PlayersPerTeam];

                while (true)
                {
                    for (int i = 0; i < PlayersPerTeam; i++)
                    {
                        PermuteArray[i] = r.Next(0, BuildList.Count());
                        for (int j = 0; j < i; j++)
                        {
                            if (PermuteArray[i] == PermuteArray[j])
                            {
                                i--;
                            }
                        }
                    }

                    int[] RatingArray = new int[PermuteArray.Count()];

                    for (int i = 0; i < PermuteArray.Count(); i++)
                    {
                        RatingArray[i] = TotalRating[PermuteArray[i]];
                    }

                    if (RatingTeamA == RatingArray.Sum())
                    {
                        for (int i = 0; i < PermuteArray.Count(); i++)
                        {
                            TeamOne.Add(BuildList[PermuteArray[i]]);
                        }
                        TeamTwo = BuildList.Except(TeamOne).ToList();
                        break;
                    }
                }
                
                ///End
            }
            else
            {
                int[] TotalRating = new int[BuildList.Count];

                for (int i = 0; i < BuildList.Count; i++)
                {
                    TotalRating[i] = BuildList[i].FirstAtt + BuildList[i].SecondAtt;
                }

                int lowest = TotalRating.Min();


                for (int i = 0; i < BuildList.Count; i++)
                {
                    
                    if (lowest == TotalRating[i])
                    {
                        BicholiBox.Text = "Bicholi:"+ BuildList[i].Name;
                        BuildList.RemoveAt(i);
                        break;
                    }
                }
                int RatingsForTeams = TotalRating.Sum();
                int RatingTeamA;

                RatingTeamA = RatingsForTeams / 2;

                int PlayersPerTeam = BuildList.Count / 2;

                Random r = new Random();

                int[] PermuteArray = new int[PlayersPerTeam];

                while (true)
                {
                    for (int i = 0; i < PlayersPerTeam; i++)
                    {
                        PermuteArray[i] = r.Next(0, BuildList.Count());
                        for (int j = 0; j < i; j++)
                        {
                            if (PermuteArray[i] == PermuteArray[j])
                            {
                                i--;
                            }
                        }
                    }

                    int[] RatingArray = new int[PermuteArray.Count()];

                    for (int i = 0; i < PermuteArray.Count(); i++)
                    {
                        RatingArray[i] = TotalRating[PermuteArray[i]];
                    }

                    if (RatingTeamA == RatingArray.Sum())
                    {
                        for (int i = 0; i < PermuteArray.Count(); i++)
                        {
                            TeamOne.Add(BuildList[PermuteArray[i]]);
                        }
                        TeamTwo = BuildList.Except(TeamOne).ToList();
                        break;
                    }
                }

                ///End
            }


            TeamA.DataContext = PlayersModelTeamOne;
            TeamB.DataContext = PlayersModelTeamTwo;
        }

        public bool Helper(List<Player> a, List<Player> b, int i, int j)
        {
            if (a[i].Name == b[j].Name && a[i].FirstAtt == b[j].FirstAtt && a[i].SecondAtt == b[j].SecondAtt)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool CheckEven(int a)
        {
            int b = a % 2;
            if (b==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        
    }
}
