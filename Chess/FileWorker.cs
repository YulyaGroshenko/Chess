using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;


namespace Chess.Logic
{
    static class FileWorker
    {
        public static DirectoryInfo Saves
        {
            get
            {
                if (!Directory.Exists("Saves"))
                    Directory.CreateDirectory("Saves");
                return new DirectoryInfo("Saves");
            }
        }
        public static List<string> Records { get; private set; } = new List<string>() {"1) name1 - 0", 
                                                                                       "2) name2 - 0",
                                                                                       "3) name3 - 0",
                                                                                       "4) name4 - 0",
                                                                                       "5) name5 - 0"};
        public static void AddPlayer(Player player)
        {
            int nameNullCount = 0;
            for (int i = 0; i < Records.Count; i++)
            {
                if (Records[i].Contains(player.Name))
                    break;
                else
                    nameNullCount++;
            }  
            if (nameNullCount == Records.Count)
            {
                Records.Add($"6) {player.Name} - {player.Victorys}");
                Bo
            }
        }
        //Records[i].Split(" ")[1] = player.Name;
        //Records[i].Split(" ")[3] = player.Victorys.ToString();
        public static void SortRecords()
        {
            for (int i = 0; i < Records.Count; i++)
            {
                for (int j = 0; j < Records.Count - i - 1; j++)
                {
                    if (int.Parse(Records[j].Split(" ")[3]) > int.Parse(Records[j + 1].Split(" ")[3]))
                    {
                        string temp = Records[j];
                        Records[j] = Records[j + 1];
                        Records[j + 1] = temp;
                    }
                }
            }
        }
        public static void SavePlayer(Player player)
        {
            string json = JsonConvert.SerializeObject(player);
            File.WriteAllText($"{Saves.Name}\\{player.Name}", json);
        }
        public static Player GetPlayer(string name)
        {
            return JsonConvert.DeserializeObject<Player>(File.ReadAllText($"{Saves.Name}\\name"));
        }
        
    }
}
