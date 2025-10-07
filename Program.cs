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















































































