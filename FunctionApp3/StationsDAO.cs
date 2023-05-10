using System.Collections.Generic;
using MySqlConnector;

namespace FunctionApp3
{

    struct Station
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    class StationsDAO
    {

        public Station getStationDetails(string id)
        {
    
            using MySqlConnection connection = openConnection();
            string sql = "select * from Stations1 where Stations1.Id = \"" + id +  "\"";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Station> list = new List<Station>();
            rdr.Read();
            Station station = new Station
            {
                Name = (string)rdr[2],
                Address= (string)rdr[5],
                Lat = (double)rdr[11],
                Lon = (double)rdr[12]
            };
            return station;
               
            
        }
        public List<Station> ListStations(int page)
        {
            Connection conn = new Connection();

            using MySqlConnection connection = conn.getConnection();
            string sql = "select * from databasename.Stations1 LIMIT 10 OFFSET  " + (page *10) + ";";
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

        private static MySqlConnection openConnection()
        {
            var connection = new MySqlConnection("Server=localhost;User ID=root;Password=123456;Database=databasename");
            connection.Open();
            return connection;
        }
    }
}
