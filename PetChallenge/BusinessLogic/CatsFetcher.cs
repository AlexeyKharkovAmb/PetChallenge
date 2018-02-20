using System;
using System.Collections.Generic;
using System.Linq;
using PetChallenge.Models;

namespace PetChallenge.BusLogic
{
    public class CatsFetcher
    {
        public static GenderViewModel FetchCats(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("Input Json string is empty");
            }

            //deserialize object and fetch records containing people with Cats only (we dont need people without pets or without cats)
            var people = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<Person>>(json).Where(person => person.Pets != null && person.Pets.Any(pet => pet.Type == "Cat"));

            var genderModel = new GenderViewModel();

            //fill view model
            foreach (var person in people)
            {
                foreach (var pet in person.Pets)
                {
                    if (pet.Type == "Cat")
                    {
                        if (person.Gender == "Male")
                        {
                            genderModel.Males.Add(pet.Name);
                        }
                        else
                        {
                            //assume nothing. if gender is not Male it does not mean its Female
                            if (person.Gender == "Female")
                            {
                                genderModel.Females.Add(pet.Name);
                            }
                        }
                    }
                }
            }

            //sort all male entries
            genderModel.Males = genderModel.Males.OrderBy(x => x).ToList();

            //sort all female entries
            genderModel.Females = genderModel.Females.OrderBy(x => x).ToList();

            return genderModel;
        }
    }
}