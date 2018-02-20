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
            var people = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<Person>>(json).Where(person => person.pets != null && person.pets.Any(pet => pet.type == "Cat"));

            var genderModel = new GenderViewModel();

            //fill view model
            foreach (var person in people)
            {
                foreach (var pet in person.pets)
                {
                    if (pet.type == "Cat")
                    {
                        if (person.gender == "Male")
                        {
                            genderModel.Males.Add(pet.name);
                        }
                        else
                        {
                            //assume nothing. if gender is not Male it does not mean its Female
                            if (person.gender == "Female")
                            {
                                genderModel.Females.Add(pet.name);
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