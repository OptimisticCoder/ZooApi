namespace ZooApi.ApiBlueprint.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Request
    {
        public Dictionary<String, String> Headers { get; set; }

        public String Body { get; set; }
    }
}
