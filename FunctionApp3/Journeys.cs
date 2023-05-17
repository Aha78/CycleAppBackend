using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Text;
namespace FunctionApp3
{
    public static class  Journeys
    {
  
            [FunctionName("Journeys")]
            public static async Task<HttpResponseMessage> run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
                ILogger log)
            {

                ListJourneysBLA journeyBla = new();

                var answer = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(journeyBla.getJourneys(req.Query["page"]), Encoding.UTF8, "application/json")
                };
                answer.Headers.Add("Access-Control-Allow-Origin", "*");
                return answer;
            }
        
    }
}