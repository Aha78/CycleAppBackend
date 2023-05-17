using MySqlConnector;
using System.Collections.Generic;

namespace FunctionApp3
{
    class Connection
    {
        public MySqlConnection getConnection()
        {
            var connection = new MySqlConnection("Server=IP;User ID=USER;PASSWORD;Database=anttohautamakinet");
            connection.Open();
            return connection;

        }
    }
}
