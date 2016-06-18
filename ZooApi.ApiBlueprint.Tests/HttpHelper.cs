namespace ZooApi.ApiBlueprint.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Configuration;

    public class HttpHelper
    {
        public static async Task<HttpResponseMessage> DoRequest(HttpMethod method, String contentType, String uri)
        {
            String authToken = ConfigurationManager.AppSettings["AuthToken"];

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage() 
                {
                    RequestUri = new Uri(ConfigurationManager.AppSettings["RootUri"] + uri),
                    Method = method,
                };
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

                if (!String.IsNullOrEmpty(authToken))
                    request.Headers.Add("Authorization", authToken);

                using (var response = await httpClient.SendAsync(request))
                {
                    return response;
                } 
            }
        }
    }
}
