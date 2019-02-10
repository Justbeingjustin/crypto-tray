using Newtonsoft.Json;
using RestSharp;
using TaskTrayApplication.Models;

namespace TaskTrayApplication.Services
{
    public class CryptoRepository
    {
        public CryptoContainer GetCryptoPrices()
        {
            var client = new RestClient("https://api.coinlore.com/api/tickers/");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<CryptoContainer>(response.Content);
        }
    }
}