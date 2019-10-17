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
        public static async Task<TOut> PutCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Put);
        }

        public static async Task<TOut> PostCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Post);
        }

        public static async Task<TOut> DeleteCallApi<TOut>(string uri)
        {
            return await CallApi<TOut, object>(uri, null, HttpMethod.Delete);
        }

        private static async Task<TOut> CallApi<TOut, TIn>(string uri, TIn entity, HttpMethod httpMethod)
        {
            TOut result = default(TOut);

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response;
                if (httpMethod == HttpMethod.Post)
                {
                    response = await httpClient.PostAsJsonAsync(uri, entity);
                }
                else if (httpMethod == HttpMethod.Put)
                {
                    response = await httpClient.PutAsJsonAsync(uri, entity);
                }
                else
                {
                    response = await httpClient.DeleteAsync(uri);
                }
                result = await response.Content.ReadAsAsync<TOut>();
            }
            return result;
        }
    }
}
