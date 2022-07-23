namespace TrackerLibrary.Data;

public class SqlConnector : IDataConnection
{
    public PrizeModel CreatePrize(PrizeModel model)
    {
        // TODO - save to db
        model.Id = 1;
        return model;
    }
}
