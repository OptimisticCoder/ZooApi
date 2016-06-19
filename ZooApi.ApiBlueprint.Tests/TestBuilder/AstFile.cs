namespace ZooApi.ApiBlueprint.Tests.TestBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class AstFile
    {
        private List<ApiTest> tests = new List<ApiTest>();

        private Dictionary<String, String> metaData = new Dictionary<String, String>();

        private List<AstResourceGroup> resourceGroups = new List<AstResourceGroup>();

        public String Version { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public Dictionary<String, String> MetaData
        {
            get
            {
                return metaData;
            }
        }

        public List<ApiTest> Tests
        {
            get
            {
                return tests;
            }
        }

        public List<AstResourceGroup> ResourceGroups
        {
            get
            {
                return resourceGroups;
            }
        }

        public static AstFile Load(String filename)
        {
            var raw = File.ReadAllText(filename);
            return AstFile.Parse(raw);
        }

        public static AstFile Parse(String json)
        {            
            var parsed = JObject.Parse(json)["ast"];

            var ast = new AstFile();
            ast.Version = (String)parsed["_version"];
            foreach(var d in parsed["metadata"])
            {
                ast.MetaData.Add((String)d["name"], (String)d["value"]);
            }
            ast.Name = (String)parsed["name"];
            ast.Description = (String)parsed["description"];

            foreach (var g in parsed["resourceGroups"])
            {
                var group = new AstResourceGroup
                {
                    Name = (String)g["name"],
                    Description = (String)g["description"]
                };
                foreach (var r in g["resources"])
                {
                    var resource = new AstResource
                    {
                        Name = (String)r["name"],
                        Description = (String)r["description"],
                        UriTemplate = (String)r["uriTemplate"]
                    };
                    foreach (var a in r["actions"])
                    {
                        var method = HttpMethod.Get;
                        switch(((String)a["method"]).ToUpper())
                        {
                            case "DELETE":
                                method = HttpMethod.Delete;
                                break;
                            case "HEAD":
                                method = HttpMethod.Head;
                                break;
                            case "OPTIONS":
                                method = HttpMethod.Options;
                                break;
                            case "POST":
                                method = HttpMethod.Post;
                                break;
                            case "PUT":
                                method = HttpMethod.Put;
                                break;
                            case "TRACE":
                                method = HttpMethod.Trace;
                                break;
                        }

                        var action = new AstAction
                        {
                            Method = method
                        };

                        resource.Actions.Add(action);
                    }
                    group.Resources.Add(resource);
                }
                ast.ResourceGroups.Add(group);
            }


            return ast;
        }
    }
}
