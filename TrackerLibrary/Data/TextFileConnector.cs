using TrackerLibrary.Models;
using TrackerLibrary.Data.TextFileConnectorExtensions;

namespace TrackerLibrary.Data;

public class TextFileConnector : IDataConnection
{
    private const string PrizesFile = "PrizeModels.csv";
    private const string PeopleFile = "PeopleModels.csv";

    public PersonModel CreatePerson(PersonModel model)
    {
        var people = PeopleFile.FullFilePath().LoadFile().MapToPeople();

        var currentId = 1;

        if (people.Any()) currentId = people.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;

        model.Id = currentId;
        people.Add(model);

        people.SaveToPeopleFile(PeopleFile);

        return model;
    }

    public PrizeModel CreatePrize(PrizeModel model)
    {
        var prizes = PrizesFile.FullFilePath().LoadFile().MapToPrizes();

        var currentId = 1;

        if (prizes.Any()) currentId = prizes.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;

        model.Id = currentId;
        prizes.Add(model);

        prizes.SaveToPrizeFile(PrizesFile);

        return model;
    }

    public List<PersonModel> GetAllPeople()
    {
        throw new NotImplementedException();
    }
}
