using TrackerLibrary.Models;

namespace TrackerLibrary.Data;

public interface IDataConnection
{
    PrizeModel CreatePrize(PrizeModel model);
}
