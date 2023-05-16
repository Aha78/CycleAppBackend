using System.Collections.Generic;
using MySqlConnector;

namespace FunctionApp3
{

    struct Station
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public   int NumDeb { get; set; }
        public int NumEnd { get; set; }
    }

    class StationsDAO
    {

        public Station getStationDetails(string id)
        {
            JourneysDao journeysDao = new ();
            int totalDeb = journeysDao.getNumberstartingJourneys(id);
            int totalEnd = journeysDao.getNumberendingJourneys(id);
            Connection conn = new ();
            MySqlConnection connection=conn.getConnection ();
            string sql = "select * from Stations1 where Stations1.Id = \"" + id + "\"";
            MySqlCommand cmd = new (sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            Station station = new()
            {
                
                Name = (string)rdr[2],
                Address = (string)rdr[5],
                Lat = (double)rdr[12],
                Lon = (double)rdr[11],
                NumDeb = totalDeb,
                NumEnd = totalEnd  
            };
            connection.Close ();
            return station;


        }
        public List<Station> ListStations(int page)
        {
            Connection conn = new Connection();

            using MySqlConnection connection = conn.getConnection();

            string sql = "select * from databasename.Stations1 LIMIT 10 OFFSET  " + (page * 10) + ";";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Station> list = new List<Station>();

            while (rdr.Read())
            {
                Station station = new Station
                {
                    id = (string)rdr[1],
                    Name = (string)rdr[2]
                };
                list.Add(station);
            }
            return list;

        }
    }
}
