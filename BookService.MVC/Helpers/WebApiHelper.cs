using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookService.WebAPI.Helpers
{
    public static class WebApiHelper
    {
        public static T GetApiResult<T>(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew(
                    () => JsonConvert.DeserializeObject<T>(response.Result)
                    ).Result;
            }
        }
    }
}
