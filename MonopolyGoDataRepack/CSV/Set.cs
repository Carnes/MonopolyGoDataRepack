using Microsoft.VisualBasic;

namespace MonopolyGoDataRepack.CSV;

public class Set
{
    public int Number { get; set; }
    public List<Sticker> Stickers { get; private set; }

    public Set(int number, List<Sticker> stickers)
    {
        Number = number;
        if (stickers.Count != 9)
            throw new Exception($"Set {Number} was only give {stickers.Count} stickers");
        
        for(int i = 0; i<stickers.Count; i++)
        {
            stickers[i].OrderNumber = i + 1;
        }

        Stickers = stickers;
    }

    public void Print()
    {
        Console.WriteLine($"Set {Number}");
        foreach(var s in Stickers)
            s.PrintFullLine();
    }

    public void PrintAsGrid()
    {
        Console.WriteLine($"Set {Number}");
        var s = 0;
        var colPadding = new List<int> { 30, 30, 0 };
        for (var row = 0; row < 3; row++)
        {
            for (var col = 0; col < 3; col++)
            {
                var text = Stickers[s++].PrintShort();
                var colPadAmount = colPadding[col] - text.Length;
                
                var padding = colPadAmount > 0 ? Strings.Space(colPadAmount) : ""; 
                // Console.Write($"{text}{padding}");
                Console.Write(padding);
            }
            Console.WriteLine();
        }
    }

}