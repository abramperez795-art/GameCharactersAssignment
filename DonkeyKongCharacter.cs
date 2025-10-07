public partial class DonkeyKongCharacter : Character
{
    public string? Species { get; set; }

    public override string Display() => $"{Id}: {Name} ({Species}) - {Description}";
}
