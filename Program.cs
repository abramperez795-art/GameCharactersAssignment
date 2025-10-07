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

while (true)
{
    Console.WriteLine("1. Display Donkey Kong Characters");
    Console.WriteLine("2. Add Donkey Kong Character");
    Console.WriteLine("3. Remove Donkey Kong Character");
    Console.WriteLine("4. Display Street Fighter II Characters");
    Console.WriteLine("5. Add Street Fighter II Character");
    Console.WriteLine("6. Remove Street Fighter II Character");
    Console.WriteLine("Enter to quit.");

    var choice = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(choice))
        break;
                        //menu
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
    if (string.IsNullOrEmpty(idInput) || !ulong.TryParse(idInput, out id))
    {
        Console.WriteLine("Invalid ID input. Defaulting to 0.");
    }
    return new DonkeyKongCharacter { Id = id, Name = name, Species = species, Description = desc };
}

SF2Character InputSF2Character()
{
    Console.WriteLine("Name:");
    var name = Console.ReadLine() ?? "";
    Console.WriteLine("Description:");
    var desc = Console.ReadLine() ?? "";
    Console.WriteLine("Moves (comma separated):");
    var movesInput = Console.ReadLine();
    var moves = movesInput != null ? movesInput.Split(',').Select(x => x.Trim()).ToList() : new List<string>();
    Console.WriteLine("ID:");
    var idInput = Console.ReadLine();
    ulong id = 0;
    if (string.IsNullOrEmpty(idInput) || !ulong.TryParse(idInput, out id))
    {
        Console.WriteLine("Invalid ID input. Defaulting to 0.");
    }
    return new SF2Character { Id = id, Name = name, Description = desc, Moves = moves };
}
