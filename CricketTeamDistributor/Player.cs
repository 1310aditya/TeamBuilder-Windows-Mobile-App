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

    public static class MyClass
    {
        public static List<Player> SelectedList;
    }

    public class PlayerFile 
    {
        public const string CricketTeamFile = "CricketFile";
        public const string FootballTeamFile= "FootballFile";
        
        //public static async Task<List<Player>> ViewMyPlayers(string type)
        //{
        //    List<Player> Team;
        //    var Serializer = new DataContractJsonSerializer(typeof(List<Player>));
        //    if (type == "Cricket")
        //    {
        //        var MyStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(CricketTeamFile);
        //        Team = (List<Player>)Serializer.ReadObject(MyStream);
        //    }
        //    else
        //    {
        //        var MyStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FootballTeamFile);
        //        Team = (List<Player>)Serializer.ReadObject(MyStream);
        //    }
        //    return Team;
        //}

        //public static async Task AddToFile(List<Player> a, string type)
        //{
        //    var serializer = new DataContractJsonSerializer(typeof(List<Player>));
        //    if (type == "Cricket")
        //    {
        //        using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(CricketTeamFile, CreationCollisionOption.ReplaceExisting))
        //        {
        //            serializer.WriteObject(stream, a);
        //        }
        //    }
        //    else
        //    {
        //        using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(FootballTeamFile, CreationCollisionOption.ReplaceExisting))
        //        {
        //            serializer.WriteObject(stream, a);
        //        }
        //    }
        //}

        public static async Task AddToFile(List<Player> a, string type)
        {
            if (type == "Cricket")
            {
                await JsonSerialization.WriteToJsonFile(CricketTeamFile,a);
            }
            else
            {
                await JsonSerialization.WriteToJsonFile(FootballTeamFile, a);
            }
        }

        public static async Task<List<Player>> ViewMyPlayers(string type)
        {
            List<Player> Team;
            //var Serializer = new DataContractJsonSerializer(typeof(List<Player>));
            if (type == "Cricket")
            {
                Team = await JsonSerialization.ReadFromJsonFile(CricketTeamFile);
            }
            else
            {
                Team = await JsonSerialization.ReadFromJsonFile(FootballTeamFile);
            }
            return Team;
        }

    }

    public static class JsonSerialization
    {
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static async Task WriteToJsonFile(string filePath, List<Player> x)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = Newtonsoft.Json.JsonConvert.SerializeObject(x);
                //writer = new StreamWriter(filePath,append);
                var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(filePath, CreationCollisionOption.ReplaceExisting);
                writer = new StreamWriter(stream);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Dispose();
            }
        }

        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
        public async static Task<List<Player>> ReadFromJsonFile(string filePath)
        {
            TextReader reader = null;
            try
            {
                var MyStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(filePath);
                reader = new StreamReader(MyStream);
                var fileContents = reader.ReadToEnd();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Player>>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }
        }
    }
}
