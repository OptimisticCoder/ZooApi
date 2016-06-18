namespace ZooApi.ApiBlueprint.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Category
    {
        public String Name { get; set; }

        public List<Resource> Resources { get; set; }
    }
}
