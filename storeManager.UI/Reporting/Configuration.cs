using System.Configuration;


public static class ConfigurationHelper
{
    // Caches the connection string
    private static string dbConnectionString;
    private static string testdbConnectionString;
    // Caches the data provider name 
    private static string dbProviderName;

    static ConfigurationHelper()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["StoreManagerConnString"].ConnectionString;
        testdbConnectionString = ConfigurationManager.ConnectionStrings["TestStoreManagerConnString"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["StoreManagerConnString"].ProviderName;
    }

    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    public static string TestDbConnectionString
    {
        get
        {
            return testdbConnectionString;
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
}
