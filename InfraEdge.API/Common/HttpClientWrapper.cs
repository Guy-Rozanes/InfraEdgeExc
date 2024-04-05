using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEdge.API.Common
{
    public class HttpClientWrapper
    {
        private HttpClient _httpClient;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> SendRequestAsync(CustomMethods method, string url, string body = null)
        {
            HttpMethod httpMethod = new HttpMethod(method.ToString());

            using (var request = new HttpRequestMessage(httpMethod, url))
            {
                if (!string.IsNullOrEmpty(body))
                {
                    request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                }

                HttpResponseMessage response = await _httpClient.SendAsync(request);
                return await response.Content.ReadAsStringAsync();

            }
        }
    }
}
