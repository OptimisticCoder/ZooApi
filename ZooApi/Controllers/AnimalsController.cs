namespace ZooApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;

    public class AnimalsController : ApiController
    {
        private static List<Animal> animals = new List<Animal>();

        public AnimalsController()
        {
            if (animals.Count > 0)
                return;

            animals.Add(new Animal
            {
                name = "Malcom",
                type = "Monkey",
                status = AnimalStatus.zoo,
                created_at = DateTime.Now
            });

            animals.Add(new Animal
            {
                name = "Eddie",
                type = "Elephant",
                status = AnimalStatus.wild,
                created_at = DateTime.Now.AddDays(-1)
            });

            animals.Add(new Animal
            {
                name = "Tony",
                type = "Tiger",
                status = AnimalStatus.transport,
                created_at = DateTime.Now.AddYears(-1)
            });
        }

        public IEnumerable<Animal> GetAllAnimals()
        {
            return animals;
        }

        public Animal GetAnimalByName(String id)
        {
            return animals.Where(a => a.name.ToLower() == id)
                          .FirstOrDefault();
        }

        public void PutAnimal(String id, Animal animal)
        {
            var exists = animals.Where(a => a.name.ToLower() == id).FirstOrDefault();
            if (exists == null)
                return;

            exists.name = animal.name;
            exists.status = animal.status;

            // ...
        }

        public void DeleteAnimal(String id)
        {
            var exists = animals.Where(a => a.name.ToLower() == id).FirstOrDefault();
            if(exists != null)
                animals.Remove(exists);
        }
    }
}
