using TrackerLibrary.Data.TextFileConnectorExtensions;
using TrackerLibrary.Models;

namespace TrackerLibrary.Data;

public class TextFileConnector : IDataConnection
{
    private const string PrizesFile = "PrizeModels.csv";

    public PrizeModel CreatePrize(PrizeModel model)
    {
        var prizes = PrizesFile.FullFilePath().LoadFile().MapToPrizes();

        var currentId = 0;

        if (prizes.Any()) currentId = prizes.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
        else currentId = 1;

        model.Id = currentId;
        prizes.Add(model);

        prizes.SaveToPrizeFile(PrizesFile);

        return model;
    }
}
