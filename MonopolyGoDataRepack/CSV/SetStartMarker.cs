namespace MonopolyGoDataRepack.CSV;

public class SetStartMarker
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool HasPrecheck => !string.IsNullOrEmpty(Precheck);
    public string? Precheck { get; set; } = null;

    public SetStartMarker(int x, int y, string precheck = null)
    {
        X = x;
        Y = y;
        Precheck = precheck;
    }
}