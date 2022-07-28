using System.Configuration;
using TrackerLibrary.Models;

namespace TrackerLibrary.Data;

public static class GlobalConfig
{
    public static IDataConnection Connection { get; private set; }

    public static void InitializeConnections(ConnectionType connectionType)
    {
        if (connectionType == ConnectionType.Sql)
        {
            // TODO - Create sql connexion
            var sql = new SqlConnector();
            Connection = sql;
        }
        else if (connectionType == ConnectionType.TextFile)
        {
            // TODO - Create txt connexion
            var textFile = new TextFileConnector();
            Connection = textFile;
        }
    }

    public static string ConnectionString(string path)
    {
        return ConfigurationManager.ConnectionStrings[path].ConnectionString;
    }
}
