using System.Configuration;


public static class ConfigurationHelper
{
    // Caches the connection string
    private static string dbConnectionString;
    // Caches the data provider name 
    private static string dbProviderName;

    private static string oracleConnection;

    private static string path;

    static ConfigurationHelper()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["StoreManagerConnString"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["StoreManagerConnString"].ProviderName;
        //oracleConnection = ConfigurationManager.ConnectionStrings["oracleConnection"].ConnectionString;
        //path = ConfigurationManager.AppSettings["path"].ToString();

    }

    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    public static string OracleConnection
    {
        get
        {
            return oracleConnection;
        }
    }

    // Returns the data provider name
    public static string DbProviderName
    {
        get
        {
            return dbProviderName;
        }
    }

    public static string Path
    {
        get
        {
            return path;
        }
    }
}
