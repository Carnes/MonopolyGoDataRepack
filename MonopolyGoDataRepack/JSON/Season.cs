namespace MonopolyGoDataRepack.JSON;

public class Season
{
    public string Name { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public List<Set> Sets { get; set; }
}