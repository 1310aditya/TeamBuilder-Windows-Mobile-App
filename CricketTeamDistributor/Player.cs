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


namespace CricketTeamDistributor.Assets
{
    public class Player
    {
        public string Name { get; set; }
        public int FirstAtt { get; set; }
        public int SecondAtt { get; set; }
    }

    public class PlayerFile 
    {
        private const string CricketTeamFile = "CricketFile";
        private const string FootballTeamFile= "FootballFile";
        
        public static async Task<List<Player>> ViewMyPlayers(string type)
        {
            List<Player> Team;
            var Serializer = new DataContractJsonSerializer(typeof(List<Player>));
            if (type == "Cricket")
            {
                var MyStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(CricketTeamFile);
                Team = (List<Player>)Serializer.ReadObject(MyStream);
            }
            else
            {
                var MyStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FootballTeamFile);
                Team = (List<Player>)Serializer.ReadObject(MyStream);
            }
            return Team;
        }

        public static async Task AddToFile(List<Player> a, string type)
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Player>));
            if (type == "Cricket")
            {
                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(CricketTeamFile, CreationCollisionOption.ReplaceExisting))
                {
                    serializer.WriteObject(stream, a);
                }
            }
            else
            {
                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(FootballTeamFile, CreationCollisionOption.ReplaceExisting))
                {
                    serializer.WriteObject(stream, a);
                }
            }
        }
        
    }
}
