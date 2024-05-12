namespace MonopolyGoDataRepack.JSON;

public class Set
{
    public string Name { get; set; }
    public int Number { get; set; }
    public bool IsComplete { get; set; }
    public List<Card> Cards { get; set; }
}