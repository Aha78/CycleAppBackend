using MySqlConnector;
using System;
using System.Collections.Generic;

namespace FunctionApp3
{
    struct Journey
    {
        public string start;
        public string end;
        public string duration;
        public string distance;
    };

    class JourneysDao
    {
        public int getNumberstartingJourneys(string stationID)
        {
            Connection conn = new();
            string sql = "select count(*) from databasename.journeys where databasename.journeys.Departure_station_id='" + stationID + "';";
            MySqlConnection connection = conn.getConnection();
            MySqlCommand cmd = new(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            return Int32.Parse("" +rdr[0]);
        }

        public int getNumberendingJourneys(string stationID)
        {
            Connection conn = new();
            string sql = "select count(*) from databasename.journeys where databasename.journeys.Return_station_id='" + stationID + "';";
            MySqlConnection connection = conn.getConnection();
            MySqlCommand cmd = new(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            return Int32.Parse("" + rdr[0]);
        }
        public List<Journey> getList(string page)
        {
      
            Connection conn=new();

            string sql = "select * from databasename.journeys LIMIT 10 OFFSET  " + (Int16.Parse(page) * 10) + ";";
            MySqlConnection connection = conn.getConnection();
            MySqlCommand cmd = new(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Journey> journeys = new();

            while (rdr.Read())
            {
                Journey journey = new()
                {
                    start = rdr[3].ToString(),
                    end =rdr[5].ToString(),
                    distance = rdr[6].ToString().Trim(),
                    //to escape  necessary chars
                    duration = rdr[7].ToString().Trim()
                };
                journeys.Add(journey);
            }

            connection.Close();
            return journeys;
        }
    }
}
