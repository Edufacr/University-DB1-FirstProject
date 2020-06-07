using System.Data.SqlClient;
using University_DB1_FirstProject.Interfaces;

namespace University_DB1_FirstProject
{
    public class DBConnection
    {
        private string connectionString = IConnectionStrings.CONNECTIONSTRING;
        public SqlConnection Connection;
        public static DBConnection Singleton;

        private DBConnection()
        {
            Connection = new SqlConnection();
            Connection.ConnectionString = connectionString;
        }

        public static DBConnection getInstance()
        {
            return Singleton ??= new DBConnection();
        }

        
    }
}