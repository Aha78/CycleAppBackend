using Newtonsoft.Json;

namespace FunctionApp3
{
    class ListStationsBLA
    {
        public string ListStations(int page)
        {
            StationsDAO StationsDAO = new StationsDAO();
            return JsonConvert.SerializeObject(StationsDAO.ListStations(page));
        }
    }
}
