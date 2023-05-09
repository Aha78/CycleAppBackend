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


using System.Net.Http;
using System.Net;
using Org.BouncyCastle.Ocsp;

namespace FunctionApp3
{






    public static class Function2
    {
        [FunctionName("stationdetails")]
        public static async Task<HttpResponseMessage> run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            ListStationsBLA stationDetails = new ListStationsBLA();
         
            var answer = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(stationDetails.getStationDetails(req.Query["id"]), Encoding.UTF8, "application/json")
            };
            answer.Headers.Add("Access-Control-Allow-Origin", "*");
            return answer;

        }

        [FunctionName("stations")]
        public static async Task<HttpResponseMessage> runDetails(
    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
    ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            ListStationsBLA listStations = new ListStationsBLA();
            var answer = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(listStations.ListStations(Int16.Parse(req.Query["page"])), Encoding.UTF8, "application/json")
            };
            answer.Headers.Add("Access-Control-Allow-Origin", "*");
            return answer;

        }
    }
}
