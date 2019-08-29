using System.Collections.Generic;

namespace PetChallenge.Models
{
    public class GenderViewModel
    {
        public List<string> Males { get; set; }
        public List<string> Females { get; set; }

        public GenderViewModel()
        {
            Males = new List<string>();
            Females = new List<string>();
        }
    }
}