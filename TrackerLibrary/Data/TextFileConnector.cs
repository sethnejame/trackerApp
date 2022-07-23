namespace TrackerLibrary.Data;

public class TextFileConnector : IDataConnection
{
    public PrizeModel CreatePrize(PrizeModel model)
    {
        // TODO - save to text file
        model.Id = 1;
        return model;
    }
}
