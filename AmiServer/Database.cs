using System.Data;
using MySql.Data.MySqlClient;

namespace AmiServer
{
    public static class Database
    {
        public static IDbConnection GetConnection()
        {
            const string server = "localhost";
            const string database = "techucat_ami";
            const string uid = "techu_ami";
            const string password = "L7*0hf2l";
            const string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                                            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}