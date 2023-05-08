using System.Collections.Generic;
using MySqlConnector;

namespace FunctionApp3
{
    class StationsDAO
    {
        public List<Station> ListStations()
        {
            using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=123456;Database=databasename");
            connection.Open();
            string sql = "select * from databasename.Stations1;'";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Station> list = new List<Station>();

            while (rdr.Read())
            {
                Station station = new Station();
                station.Name = (string)rdr[2];
                list.Add(station);
            }
            return list;

        }
    }
}
