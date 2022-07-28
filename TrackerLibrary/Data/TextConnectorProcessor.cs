using System.Configuration;
using TrackerLibrary.Models;

namespace TrackerLibrary.Data.TextFileConnectorExtensions;

public static class TextFileConnectorProcessor
{
    public static string FullFilePath(this string fileName)
    {
        return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
    }

    public static List<string> LoadFile(this string file)
    {
        if (!File.Exists(file)) return new List<string>();

        return File.ReadAllLines(file).ToList();
    }

    public static List<PrizeModel> MapToPrizes(this List<string> lines)
    {
        var output = new List<PrizeModel>();

        foreach (var line in lines)
        {
            var cols = line.Split(',');

            var prizeModel = new PrizeModel()
            {
                Id = int.Parse(cols[0]),
                PlaceNumber = int.Parse(cols[1]),
                PlaceName = cols[2],
                PrizeAmount = decimal.Parse(cols[3]),
                PrizePercentage = double.Parse(cols[4])
            };

            output.Add(prizeModel);
        }

        return output;
    }

    public static void SaveToPrizeFile(this List<PrizeModel> prizes, string fileName)
    {
        var lines = new List<string>();

        foreach (var prize in prizes)
            lines.Add($"{prize.Id},{prize.PlaceNumber},{prize.PlaceName},{prize.PrizeAmount},{prize.PrizePercentage}");

        File.WriteAllLines(fileName.FullFilePath(), lines);
    }
}
