namespace TrackerLibrary.Data;

public static class GlobalConfig
{
    public static List<IDataConnection> Connections { get; private set; } = new();

    public static void InitializeConnections(bool database, bool textFiles)
    {
        if (database)
        {
            // TODO - Create sql connexion
            var db = new SqlConnector();
            Connections.Add(db);
        }

        if (textFiles)
        {
            // TODO - Create txt connexion
            var textFile = new TextFileConnector();
            Connections.Add(textFile);
        }
    }
}
