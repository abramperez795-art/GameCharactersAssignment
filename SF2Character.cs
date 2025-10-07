public partial class SF2Character : Character
{
    public List<string> Moves { get; set; } = new List<string>();
    public override string Display() => $"{Id}: {Name} - {Description} Moves: {string.Join(", ", Moves)}";
}

