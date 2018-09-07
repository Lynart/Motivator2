using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motivator2
{
    public class Stats
    {
        static string FILE_LOCATION = @"C:\Users\vlee\Desktop\Stats.json";
        //These must be public or json.net won't serialize them
        //There is an override flag though via [JsonProperty]
        public int DaysPassed { get; set; }
        public DateTime LastAccessed { get; set; }

        public Stats()
        {
            //Check if file exists
            DaysPassed = 0;
            LastAccessed = DateTime.Now.Date;
        }

        //Common sense would say to put this in the constructor;
        //infinite loop will result however as typeof calls the default constructor
        public void Load()
        {
            if (File.Exists(FILE_LOCATION))
            {
                using (StreamReader file = File.OpenText(FILE_LOCATION))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Stats temp = (Stats)serializer.Deserialize(file, typeof(Stats));
                    DaysPassed = temp.DaysPassed;
                    LastAccessed = temp.LastAccessed;
                }
            }
        }

        public int GetProgress()
        {
            int daysSinceLastAccessed = (DateTime.Now.Date - LastAccessed).Days;
            return daysSinceLastAccessed + DaysPassed;
        }

        public void Save()
        {
            DaysPassed += (DateTime.Now.Date - LastAccessed).Days;
            LastAccessed = DateTime.Now.Date;
            using (StreamWriter file = File.CreateText(FILE_LOCATION))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, this);
            }
        }
    }
}
