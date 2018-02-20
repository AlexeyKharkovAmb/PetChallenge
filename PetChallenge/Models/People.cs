using System.Collections.Generic;

namespace PetChallenge.Models
{
    public class Person
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public List<Pet> pets { get; set; }
    }
}