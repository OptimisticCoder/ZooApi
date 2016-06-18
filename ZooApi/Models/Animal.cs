namespace ZooApi.Models
{
    using System;

    public class Animal
    {
        public String name { get; set; }

        public String type { get; set; }

        public AnimalStatus status { get; set; }

        public DateTime created_at { get; set; }
    }
}