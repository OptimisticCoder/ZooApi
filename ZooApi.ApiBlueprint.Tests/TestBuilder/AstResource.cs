namespace ZooApi.ApiBlueprint.Tests.TestBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AstResource
    {
        private List<AstAction> actions = new List<AstAction>();

        public String Name { get; set; }

        public String Description { get; set; }

        public String UriTemplate { get; set; }

        public List<AstAction> Actions
        {
            get
            {
                return actions;
            }
        }
    }
}
