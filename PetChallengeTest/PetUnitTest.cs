using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetChallenge.BusLogic;
using System.Collections.Generic;

namespace PetChallengeTest
{
    [TestClass]
    public class PetUnitTest
    {
        [TestMethod]
        public void MaleCats()
        {
            var json = "[{\"name\":\"maleA\",\"gender\":\"Male\",\"age\":20,\"pets\":[{\"name\":\"catA\",\"type\":\"Cat\"}]},{\"name\":\"femaleA\",\"gender\":\"Female\",\"age\":20,\"pets\":[{\"name\":\"catB\",\"type\":\"Cat\"}]}, {\"name\":\"femaleB\",\"gender\":\"Female\",\"age\":20,\"pets\":[{\"name\":\"catC\",\"type\":\"Cat\"}]}, {\"name\":\"femaleC\",\"gender\":\"Female\",\"age\":20,\"pets\":[{\"name\":\"dog1\",\"type\":\"Dog\"}]}]";

            var genders = CatsFetcher.FetchCats(json);

            var expectedMaleCats = 1;
            var actualMaleCats = genders.Males.Count;
           
            Assert.AreEqual(expectedMaleCats, actualMaleCats, 0, "Wrong number of male cats");
        }

        [TestMethod]
        public void FemaleCats()
        {
            var json = "[{\"name\":\"maleA\",\"gender\":\"Male\",\"age\":20,\"pets\":[{\"name\":\"catA\",\"type\":\"Cat\"}]},{\"name\":\"femaleA\",\"gender\":\"Female\",\"age\":20,\"pets\":[{\"name\":\"catB\",\"type\":\"Cat\"}]}, {\"name\":\"femaleB\",\"gender\":\"Female\",\"age\":20,\"pets\":[{\"name\":\"catC\",\"type\":\"Cat\"}]}, {\"name\":\"femaleC\",\"gender\":\"Female\",\"age\":20,\"pets\":[{\"name\":\"dog1\",\"type\":\"Dog\"}]}]";

            var genders = CatsFetcher.FetchCats(json);

            var expectedFemaleCats = 2;
            var actualFemaleCats = genders.Females.Count;

            Assert.AreEqual(expectedFemaleCats, actualFemaleCats, 0, "Wrong number of male cats");
        }

        [TestMethod]
        public void CatSorting()
        {
            var json = "[{\"name\":\"maleA\",\"gender\":\"Male\",\"age\":20,\"pets\":[{\"name\":\"A\",\"type\":\"Cat\"}]},{\"name\":\"maleB\",\"gender\":\"Male\",\"age\":20,\"pets\":[{\"name\":\"C\",\"type\":\"Cat\"}]}, {\"name\":\"maleC\",\"gender\":\"Male\",\"age\":20,\"pets\":[{\"name\":\"D\",\"type\":\"Cat\"}]}, {\"name\":\"maleD\",\"gender\":\"Male\",\"age\":20,\"pets\":[{\"name\":\"B\",\"type\":\"Cat\"}]}]";

            var genders = CatsFetcher.FetchCats(json);

            var expectedOrder = new List<string>();
            expectedOrder.Add("A");
            expectedOrder.Add("B");
            expectedOrder.Add("C");
            expectedOrder.Add("D");
                        
            var actualOrder = genders.Males;

            CollectionAssert.AreEqual(expectedOrder, actualOrder, "Wrong ordering of cats");
        }
    }
}
