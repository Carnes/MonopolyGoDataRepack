using System.Drawing;

namespace MonopolyGoDataRepack.CSV;

public class Sticker
{
    public bool IsGold { get; set; }
    public int Stars { get; set; }
    public string Name { get; set; }
    public int SetNumber { get; set; }
    
    public int OrderNumber { get; set; }

    public Sticker(string stars, string name, string setNumber, bool isGold)
    {
        IsGold = isGold;
        Name = name;
        stars = stars.Replace("⭐", "").Trim();
        Stars = int.Parse(stars);
        setNumber = setNumber.Replace("Set ", "");
        SetNumber = int.Parse(setNumber);
    }

    public void PrintFullLine()
    {
        Console.WriteLine($"{Stars}⭐ {Name} - Set {SetNumber}");
    }
    
    public string GetPrintShort()
    {
        return $"{Stars}⭐ {Name}";
    }

    public string PrintShort()
    {
        var beforeColor = Console.ForegroundColor;
        if (IsGold)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        var text = GetPrintShort();
        Console.Write(text);
        Console.ForegroundColor = beforeColor;
        return text;
    }
}