﻿using Dapper;
using System.Data;
using System.Data.SqlClient;
using TrackerLibrary.Models;

namespace TrackerLibrary.Data;

public class SqlConnector : IDataConnection
{
    public PrizeModel CreatePrize(PrizeModel model)
    {
        using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString("Tournaments")))
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
}
