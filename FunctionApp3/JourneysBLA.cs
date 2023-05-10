using Newtonsoft.Json;
using System;
namespace FunctionApp3
{
    class ListJourneysBLA
    {
        public string getJourneys(string page)
        {
            JourneysDao journeysdao = new();
            return JsonConvert.SerializeObject(journeysdao.getList(page));
        }
    }
}
