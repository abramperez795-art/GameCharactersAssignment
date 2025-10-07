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
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input) || !ulong.TryParse(input, out ulong id))
        {
            Console.WriteLine("Invalid ID input.");
        }
        else
        {
            donkeyKongList.RemoveAll(x => x.Id == id);
            File.WriteAllText("dk.json", JsonSerializer.Serialize(donkeyKongList));
        }
        break;
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
        if (string.IsNullOrEmpty(sf2Input) || !ulong.TryParse(sf2Input, out ulong sf2Id))
        {
            Console.WriteLine("Invalid ID input.");
        }
        else
        {
            sf2List.RemoveAll(x => x.Id == sf2Id);
            File.WriteAllText("sf2.json", JsonSerializer.Serialize(sf2List));
        }
        break;
}

DonkeyKongCharacter InputDonkeyKongCharacter()
{
    Console.WriteLine("Name:");
    var name = Console.ReadLine() ?? "";
    Console.WriteLine("Species:");
    var species = Console.ReadLine() ?? "";
    Console.WriteLine("Description:");
    var desc = Console.ReadLine() ?? "";
    Console.WriteLine("ID:");
    var idInput = Console.ReadLine();
    ulong id = 0;
}














































































