using MySqlConnector;
using System.Collections.Generic;

namespace FunctionApp3
{
    class Connection
    {
        public MySqlConnection getConnection()
        {
            var connection = new MySqlConnection("Server=localhost;User ID=root;Password=123456;Database=databasename");
            connection.Open();
            return connection;

        }
    }
}
