namespace ZooApi.ApiBlueprint.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Configuration;

    public class HttpHelper
    {
        public static async Task<HttpResponseMessage> DoRequest(HttpMethod method, 
                                                                String uri, 
                                                                Dictionary<String, String> headers, 
                                                                String body)
        {
            String authToken = ConfigurationManager.AppSettings["AuthToken"];

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(method, ConfigurationManager.AppSettings["RootUri"] + uri);

                var mediaType = "application/json"; // only used if we're sending a body, and overidden by the header dict below.
                if(headers != null)
                    foreach(var key in headers.Keys)
                    {
                        if (key.ToLower() == "content-type")
                            mediaType = headers[key];
                        else
                            request.Headers.Add(key, headers[key]);
                    }

                if (!String.IsNullOrEmpty(authToken))
                    request.Headers.Add("Authorization", authToken);

                if (!String.IsNullOrEmpty(body))
                    request.Content = new StringContent(body, Encoding.UTF8, mediaType);

                using (var response = await httpClient.SendAsync(request))
                {
                    return response;
                } 
            }
        }
    }
}
