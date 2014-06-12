using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
//using Oracle.DataAccess;
//using Oracle.DataAccess.Client;
using System.Configuration;
//using Oracle.DataAccess.Types;
//using System.Data.OracleClient;

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;

public static class GenericDataAccess
{
    //static string oracleConnstring = "data source=" +
    //  "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
    //  "(HOST=10.11.50.162)(PORT=1521))(CONNECT_DATA=" +
    //  "(SERVICE_NAME=GECORCL_SRV)));Connection Timeout=6000;User Id=gec_user;Password=gec_user";

    //static string oracleConnstring = ConfigurationManager.ConnectionStrings["oracleConnection"].ConnectionString;

    //static string oracleConn = "Data Source=GECORCL;User Id=gec_user;Password=gec_user;";
    //static string oradb = "Data Source=GECORCL;User Id=gec_user;Password=gec_user";
    //static string ora = "Data Source=gec_user/gec_user@gecorcl;";
    static IErrorService _logger;
    static GenericDataAccess()
    {
        _logger = new ErrorLogService();
    }

    public static string ConnToDB(out bool status)
    {
        SqlConnection conn = new SqlConnection(ConfigurationHelper.DbConnectionString);

        try
        {
            conn.Open();
            status = true;
            return "Connection to the database was successful";
        }
        catch (Exception ex)
        {
            status = false;
            _logger.LogError(ex, "Connection failed", "", "");
            throw;
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }

    public static DataTable ExecuteSelectCommand(DbCommand command,string tableName)
    {
        DataTable table;

        try
        {
            command.Connection.Open();

            DbDataReader reader = command.ExecuteReader();
            table = new DataTable(tableName);
            table.Load(reader);

            reader.Close();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred", "", "");
            throw;
        }
        finally
        {
            command.Connection.Close();
        }
        return table;
    }

   
    public static DbCommand CreateCommand()
    {
        // Obtain the database provider name
        string dataProviderName = ConfigurationHelper.DbProviderName;
        // Obtain the database connection string
        string connectionString = ConfigurationHelper.DbConnectionString;
        // Create a new data provider factory
        DbProviderFactory factory = DbProviderFactories.
        GetFactory(dataProviderName);
        // Obtain a database specific connection object
        DbConnection conn = factory.CreateConnection();
        // Set the connection string
        conn.ConnectionString = connectionString;
        // Create a database specific command object
        DbCommand comm = conn.CreateCommand();
        // Set the command type to stored procedure
        comm.CommandType = CommandType.Text;
        // Return the initialized command object
        return comm;
    }

    // execute an update, delete, or insert command 
    // and return the number of affected rows
    public static int ExecuteNonQuery(DbCommand command)
    {
        // The number of affected rows 
        int affectedRows = -1;
        // Execute the command making sure the connection gets closed in the end
        try
        {
            // Open the connection of the command
            command.Connection.Open();
            // Execute the command and get the number of affected rows
            affectedRows = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred", "", "");
            throw;
        }
        finally
        {
            // Close the connection
            command.Connection.Close();
        }
        // return the number of affected rows
        return affectedRows;
    }

    // execute a select command and return a single result as a string
    public static string ExecuteScalar(DbCommand command)
    {
        // The value to be returned 
        string value = "";
        // Execute the command making sure the connection gets closed in the end
        try
        {

            // Open the connection of the command
            command.Connection.Open();
            // Execute the command and get the number of affected rows
            value = command.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred", "", "");
            throw;
        }
        finally
        {
            // Close the connection
            command.Connection.Close();
        }
        // return the result
        return value;
    }

    public static DataTable ExecuteSelectCommand(string sql,string tableName)
    {
        try
        {
            DbCommand cmd = CreateCommand();
            cmd.CommandText = sql;
            DataTable dt = ExecuteSelectCommand(cmd, tableName);

            return dt;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred", "", "");
            throw;
        }
        
    }  
}