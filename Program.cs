using System;
using NLog;
using System.Reflection;
using System.Text.Json;

string path = Directory.GetCurrentDirectory() + "//nlog.config";

List<DonkeyKongCharacter> donkeyKongList = new List<DonkeyKongCharacter>();
List<SF2Character> sf2List = new List<SF2Character>();

if (File.Exists("dk.json"))
{
    var result = JsonSerializer.Deserialize<List<DonkeyKongCharacter>>(File.ReadAllText("dk.json"));
    donkeyKongList = result ?? new List<DonkeyKongCharacter>();
}

if (File.Exists("sf2.json"))
{
    var result = JsonSerializer.Deserialize<List<SF2Character>>(File.ReadAllText("sf2.json"));
    sf2List = result ?? new List<SF2Character>();
}

//menu 
var choice = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(choice))
        break;

    switch (choice)
    {
        case "1":
          foreach (var c in donkeyKongList)
                Console.WriteLine(c.Display());
            break;
        
        case "2":
           donkeyKongList.Add(InputDonkeyKongCharacter());
            File.WriteAllText("dk.json", JsonSerializer.Serialize(donkeyKongList));
            break;
          
        case "3":
            Console.WriteLine("Enter character ID to remove:");
       
        case "4":
            foreach (var c in sf2List)
                Console.WriteLine(c.Display());
            break;
        case "5":
            sf2List.Add(InputSF2Character());
            File.WriteAllText("sf2.json", JsonSerializer.Serialize(sf2List));
            break;
        case "6":
            Console.WriteLine("Enter character ID to remove:");
            var sf2Input = Console.ReadLine();
         
    }














































































