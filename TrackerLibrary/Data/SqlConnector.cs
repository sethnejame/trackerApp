using Dapper;
using System.Data;
using System.Data.SqlClient;
using TrackerLibrary.Models;

namespace TrackerLibrary.Data;

public class SqlConnector : IDataConnection
{
    private const string db = "Tournaments";

    public PersonModel CreatePerson(PersonModel model)
    {
        using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(db)))
        {
            var p = new DynamicParameters();
            p.Add("@FirstName", model.FirstName);
            p.Add("@LastName", model.LastName);
            p.Add("@EmailAddress", model.EmailAddress);
            p.Add("@Mobile", model.Mobile);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spPeople_CreatePerson", p, commandType: CommandType.StoredProcedure);

            model.Id = p.Get<int>("@id");

            return model;
        }
    }

    public PrizeModel CreatePrize(PrizeModel model)
    {
        using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(db)))
        {
            var p = new DynamicParameters();
            p.Add("@PlaceNumber", model.PlaceNumber);
            p.Add("@PlaceName", model.PlaceName);
            p.Add("@PrizeAmount", model.PrizeAmount);
            p.Add("@PrizePercentage", model.PrizePercentage);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spPrizes_CreatePrize", p, commandType: CommandType.StoredProcedure);

            model.Id = p.Get<int>("@id");

            return model;
        }
    }

    public List<PersonModel> GetAllPeople()
    {
        var people = new List<PersonModel>();

        using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(db)))
            people = connection.Query<PersonModel>("dbo.spPeople_GetAllPeople").ToList();

        return people;
    }
}
