using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data;
using System.Text.RegularExpressions;

namespace storeManager.UI
{
    public class DBInstaller
    {
        public void BackupDatabase(SqlConnectionStringBuilder csb, string destinationPath)
        {
            ServerConnection connection = new ServerConnection(csb.DataSource, csb.UserID, csb.Password);
            Server sqlServer = new Server(connection);

            Backup bkpDatabase = new Backup();
            bkpDatabase.Action = BackupActionType.Database;
            bkpDatabase.Database = csb.InitialCatalog;
            BackupDeviceItem bkpDevice = new BackupDeviceItem(destinationPath, DeviceType.File);
            bkpDatabase.Devices.Add(bkpDevice);
            bkpDatabase.SqlBackup(sqlServer);
            connection.Disconnect();

        }

        public void RestoreDatabase(String databaseName, String backUpFile, String serverName, String userName, String password)
        {
            ServerConnection connection = new ServerConnection(serverName, userName, password);
            Server sqlServer = new Server(connection);
            Restore rstDatabase = new Restore();
            rstDatabase.Action = RestoreActionType.Database;
            rstDatabase.Database = databaseName;
            BackupDeviceItem bkpDevice = new BackupDeviceItem(backUpFile, DeviceType.File);
            rstDatabase.Devices.Add(bkpDevice);
            rstDatabase.ReplaceDatabase = true;
            rstDatabase.SqlRestore(sqlServer);
        }


        public void RestoreDatabase(String backUpFile, SqlConnection connectionString)
        {
            KillProcess(connectionString);

            try
            {
                ServerConnection connection = new ServerConnection(connectionString);
                Server sqlServer = new Server(connection);
                Restore rstDatabase = new Restore();
                rstDatabase.Action = RestoreActionType.Database;
                rstDatabase.Database = connectionString.Database;
                BackupDeviceItem bkpDevice = new BackupDeviceItem(backUpFile, DeviceType.File);
                rstDatabase.Devices.Add(bkpDevice);
                rstDatabase.ReplaceDatabase = true;
                rstDatabase.SqlRestore(sqlServer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        void KillProcess(SqlConnection connectionString)
        {
            Server server = new Server(new ServerConnection(connectionString));
            server.KillAllProcesses(connectionString.Database);
        }

        public void AttachDB(string mdfFile, string logFile, SqlConnection connectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString.ConnectionString);
            builder.InitialCatalog = "master";

            ServerConnection connection = new ServerConnection(new SqlConnection(builder.ConnectionString));
            Server server = new Server(connection);

            try
            {
                //KillProcess(connectionString);

                server.AttachDatabase(connectionString.Database,
                    new System.Collections.Specialized.StringCollection { mdfFile, logFile }, AttachOptions.None);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void RunDBScript(string query,string seedData)
        {
            SqlConnection conn = new SqlConnection(ConfigurationHelper.TestDbConnectionString);

            try
            {
                conn.Open();

                RunScript(conn,query);
                RunScript(conn, seedData);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private static void RunScript(SqlConnection conn,string query)
        {
            IEnumerable<string> commandStringsQuery = Regex.Split(query, @"^\s*GO\s*$",
                                    RegexOptions.Multiline | RegexOptions.IgnoreCase);
           
            foreach (string commandString in commandStringsQuery)
            {
                if (commandString.Trim() != "")
                {
                    new SqlCommand(commandString, conn).ExecuteNonQuery();
                }
            }
        }
    }
}
