using System.Collections.Generic;

namespace PetChallenge.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public List<Pet> Pets { get; set; }
    }
}