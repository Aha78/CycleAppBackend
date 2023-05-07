using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySqlConnector;
using System.Net.Http;
using System.Net;

namespace FunctionApp3
{

    class Station
    {
        public string Name { get; set; }   
    }

    public static class Function2
    {
        [FunctionName("Stations")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            log.LogInformation("C# HTTP trigger function processed a request.");
            string name = req.Query["name"];
            using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=123456;Database=databasename");
            connection.Open();
            string sql = "select * from databasename.Stations1;'";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List <Station> list = new List<Station>();

            while (rdr.Read())
            {
                Station station = new Station();
                station.Name = (string)rdr[2];
                list.Add(station);
            }

            var answer = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(list), Encoding.UTF8, "application/json")
            };
            answer.Headers.Add("Access-Control-Allow-Origin", "*");
            return answer;

    }
}
}
