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

        public List<Journey> getList(string page)
        {
            Connection conn=new();

            string sql = "select * from databasename.journeys LIMIT 10 OFFSET  " + (Int16.Parse(page) * 10) + ";";
            MySqlCommand cmd = new(sql, conn.getConnection());
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Journey> journeys = new();

            while (rdr.Read())
            {
                Journey journey = new()
                {
                    start = rdr[0].ToString(),
                    end =rdr[1].ToString(),
                    distance = rdr[6].ToString().Trim(),
                    //to escape  necessary chars
                    duration = rdr[7].ToString().Trim()
                };
                journeys.Add(journey);
            }
            return journeys;
        }
    }
}
