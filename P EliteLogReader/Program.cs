using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace P_EliteLogReader
{
    class Program
    {

        #region DONT DELETE

        class eventJsonClass
        {
            [JsonProperty("timestamp")]
            public string timestamp { get; set; }

            [JsonProperty("event")]
            public string Event { get; set; }

            [JsonProperty("part")]
            public string part { get; set; }

            [JsonProperty("gameversion")]
            public string gameversion { get; set; }

            [JsonProperty("build")]
            public string build { get; set; }

            [JsonProperty("MusicTrack")]
            public string MusicTrack { get; set; }

            [JsonProperty("FID")]
            public string FID { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }


            //THE EVENT MATERIALS GIVES THESE LISTS
            [JsonProperty("Raw")]
            public Raw[] Raw { get; set; }

            [JsonProperty("Manufactured")]
            public Manufactured[] Manufactured { get; set; }

            [JsonProperty("Encoded")]
            public Encoded[] Encoded { get; set; }
            // ______________________________________________


        }

        class Raw
        {
            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Count")]
            public int Count { get; set; }


            [JsonProperty("Name_Localised")]
            public string Name_Localised { get; set; }
        }
        class Manufactured
        {
            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Count")]
            public int Count { get; set; }


            [JsonProperty("Name_Localised")]
            public string Name_Localised { get; set; }
        }
        class Encoded
        {
            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Count")]
            public int Count { get; set; }


            [JsonProperty("Name_Localised")]
            public string Name_Localised { get; set; }
        }
        #endregion

        class RecieveTextEvent
        {
            [JsonProperty("timestamp")]
            public string timestamp { get; set; }

            [JsonProperty("event")]
            public string Event { get; set; }

            [JsonProperty("From")]
            public string From { get; set; }

            [JsonProperty("From_Localised")]
            public string From_Localised { get; set; }

            [JsonProperty("Message")]
            public string Message { get; set; }

            [JsonProperty("Message_Localised")]
            public string Message_Localised { get; set; }

            [JsonProperty("Channel")]
            public string Channel { get; set; }
        }

        class ShipTargetedEvent
        {
            [JsonProperty("timestamp")]
            public string timestamp { get; set; }

            [JsonProperty("event")]
            public string Event { get; set; }

            [JsonProperty("TargetLocked")]
            public string TargetLocked { get; set; }

            [JsonProperty("Ship")]
            public string Ship { get; set; }

            [JsonProperty("ScanStage")]
            public string ScanStage { get; set; }

            [JsonProperty("PilotName")]
            public string PilotName { get; set; }

            [JsonProperty("PilotName_Localised")]
            public string PilotName_Localised { get; set; }

            [JsonProperty("PilotRank")]
            public string PilotRank { get; set; }

            [JsonProperty("ShieldHealth")]
            public string ShieldHealth { get; set; }

            [JsonProperty("HullHealth")]
            public string HullHealth { get; set; }

            [JsonProperty("Faction")]
            public string Faction { get; set; }

            [JsonProperty("LegalStatus")]
            public string LegalStatus { get; set; }


        }



        static void Main(string[] args)
        {
            string filePath = @"../../../eliteTestingJournal.log";

            string[] theFileArray = File.ReadAllLines(filePath);
            string theFile = File.ReadAllText(filePath);

            Console.WriteLine(theFile[0]);

            ShipTargetedEvent shipEvent = new ShipTargetedEvent();
            RecieveTextEvent textEvent = new RecieveTextEvent();

            for (int i = 0; i < theFileArray.Length; i++)
            {
                if (theFileArray[i].Contains("\"event\":\"ReceiveText\"")) //"event":"ReceiveText" | Dette er beskeder man får af både NPC og andre spillere
                {
                    textEvent = JsonConvert.DeserializeObject<RecieveTextEvent>(theFileArray[i]);
                }
                else if (theFileArray[i].Contains("\"event\":\"ShipTargeted\"")) //"event":"ShipTargeted" | Dette er skibe man targeter
                {

                    shipEvent = JsonConvert.DeserializeObject<ShipTargetedEvent>(theFileArray[i]);
                }

            }




            Console.WriteLine("done");

            Console.ReadLine();
        }
    }
}
