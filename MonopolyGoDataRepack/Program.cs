
using System.Text.Json;
using MonopolyGoDataRepack.CSV;

var stickerdata = File.ReadLines("stickerdata.csv");
var stickerdataY = stickerdata.Select(s => new
{
    X = s.Split(",")
}).ToArray();


var nonGoldStart = new SetStartMarker(6, 10, "Stars");
var goldStart = new SetStartMarker(10, 10, "Stars");

var allStickers = new List<Sticker>();
allStickers.AddRange(ExtractColumn(nonGoldStart));
allStickers.AddRange(ExtractColumn(goldStart, true));

var allSets = allStickers.GroupBy(s => s.SetNumber).Select(s=>new Set(s.Key, s.ToList())).OrderBy(o=>o.Number).ToList();

foreach (var set in allSets)
{
    set.PrintAsGrid();
    Console.WriteLine();
}

var json = GetJson(allSets);
File.WriteAllText("output.json", json);

string GetJson(List<Set> csvSets)
{
    var jSets = csvSets.Select(cs => new MonopolyGoDataRepack.JSON.Set
    {
        Name = $"UNKNOWN", // FIXME - how to get this?
        Number = cs.Number,
        IsComplete = false,
        Cards = cs.Stickers.Select(css=>new MonopolyGoDataRepack.JSON.Card
            {
                Name = css.Name,
                Stars = css.Stars,
                IsGold = css.IsGold,
                Number = css.OrderNumber,
            }
        ).ToList(),
    }).ToList();

    var season = new MonopolyGoDataRepack.JSON.Season
    {
        Name = $"UNKNOWN",
        StartDate = DateTime.Now.ToShortDateString(),
        EndDate = DateTime.Now.ToShortDateString(),
        IsCurrent = false,
        Sets = jSets,
    };

    var json = JsonSerializer.Serialize(season);
    return json;
}


List<Sticker> ExtractColumn(SetStartMarker startMarker, bool isGold = false)
{
    if (startMarker.HasPrecheck && Get(startMarker.X, startMarker.Y - 1) != startMarker.Precheck)
        throw new Exception("Incorrect start");

    var stickers = new List<Sticker>();
    var y = startMarker.Y;
    var x = startMarker.X;
    
    while(y <= stickerdata.Count())
    {
        var stars = Get(x, y);
        var name = Get(x+1, y);
        var set = Get(x+2, y);
        if (string.IsNullOrEmpty(stars) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(set))
            break;

        var sticker = new Sticker(stars, name, set, isGold);
        stickers.Add(sticker);
        y++;
    }

    return stickers;
}

string Get(int x, int y) => stickerdataY[y].X[x];



