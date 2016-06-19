using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApi.ApiBlueprint.Tests.TestBuilder
{
    public class AstResourceGroup
    {
        private List<AstResource> resources = new List<AstResource>();

        public String Name { get; set; }

        public String Description { get; set; }

        public List<AstResource> Resources
        {
            get
            {
                return resources;
            }
        }
    }
}
