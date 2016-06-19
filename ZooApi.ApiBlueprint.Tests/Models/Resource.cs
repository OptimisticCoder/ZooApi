namespace ZooApi.ApiBlueprint.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;

    public class Resource
    {
        public String Name { get; set; }
        public String UriTemplate { get; set; }
        public String Method { get; set; }
        public List<Response> ExpectedResponses { get; set; }
        public List<Request> ExampleRequests { get; set; }
    }
}
