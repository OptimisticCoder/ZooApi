namespace ZooApi.ApiBlueprint.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Http;

    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }

        public Dictionary<String, String> Headers { get; set; }
    }
}
