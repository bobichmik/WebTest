using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication
{
    public class CustomHttpClient : HttpClient
    {
        public async Task<T> GetJsonAsync<T>(string requestUri)
        {
            using (var httpClient = new HttpClient())
            using (var httpContent = await httpClient.GetAsync(requestUri))
            {
                string jsonContent = httpContent.Content.ReadAsStringAsync().Result;
                T obj = JsonConvert.DeserializeObject<T>(jsonContent);
                return obj;
            }
        }
        public async Task<HttpResponseMessage> PostJsonAsync<T>(string requestUri, T content)
        {
            using (var httpClient = new HttpClient())
            {
                string myContent = JsonConvert.SerializeObject(content);
                StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(requestUri, stringContent);
                return response;
            }
        }
        public async Task<HttpResponseMessage> PutJsonAsync<T>(string requestUri, T content)
        {
            using (var httpClient = new HttpClient())
            {
                string myContent = JsonConvert.SerializeObject(content);
                StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(requestUri, stringContent);
                return response;
            }
        }
    }
}  