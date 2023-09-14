using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TPP.Laboratory.ObjectOrientation.Lab04
{
    /// <summary>
    /// Clase IDictionaryTest
    /// </summary>
    [TestClass]
    public class IDictionaryTest
    {
        /// <summary>
        /// Atributos alba, omar, israel, guillermo, javier, bruce
        /// </summary>
        private Person alba, omar, israel, guillermo, javier, bruce;

        /// <summary>
        /// Método InitializeTests
        /// </summary>
        [TestInitialize]
        public void InitializeTests()
        {
            alba = new Person("Alba", "Francos", "1");
            omar = new Person("Omar", "Teixeira", "2");
            israel = new Person("Israel", "Solís", "3");
            guillermo = new Person("Guillermo", "Pulido", "4");
            javier = new Person("Javier", "Escalada", "5");
            bruce =  new Person("Bruce", "Wayne", "6");
        }

        /// <summary>
        /// Test AddCountTest
        /// </summary>
        [TestMethod]
        public void AddCountTest()
        {
            IDictionary<string, Person> people = new Dictionary<string, Person>();
            people.Add(alba.IDNumber, alba);
            people.Add(omar.IDNumber, omar);
            people.Add(israel.IDNumber, israel);
            people.Add(guillermo.IDNumber, guillermo);
            people.Add(javier.IDNumber, javier);

            Assert.AreEqual(5, people.Count);
        }

        /// <summary>
        /// Test GetSetTest
        /// </summary>
        [TestMethod]
        public void GetSetTest()
        {
            IDictionary<string, Person> people = new Dictionary<string, Person>();
            people.Add(alba.IDNumber, alba);
            people.Add(omar.IDNumber, omar);
            people.Add(israel.IDNumber, israel);
            people.Add(guillermo.IDNumber, guillermo);
            people.Add(javier.IDNumber, javier);

            Assert.AreEqual(5, people.Count);
            Assert.AreEqual(alba, people["1"]);
            Assert.AreEqual(omar, people["2"]);
            Assert.AreEqual(israel, people["3"]);
            Assert.AreEqual(guillermo, people["4"]);
            Assert.AreEqual(javier, people["5"]);

            people[alba.IDNumber]=javier;
            people[omar.IDNumber]=guillermo;
            people[israel.IDNumber]=israel;
            people[guillermo.IDNumber]=omar;
            people[javier.IDNumber]=alba;
            Assert.AreEqual(5, people.Count);
            Assert.AreEqual(javier, people["1"]);
            Assert.AreEqual(guillermo, people["2"]);
            Assert.AreEqual(israel, people["3"]);
            Assert.AreEqual(omar, people["4"]);
            Assert.AreEqual(alba, people["5"]);
        }

        /// <summary>
        /// Test ContainsTest
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            IDictionary<string, Person> people = new Dictionary<string, Person>();
            people.Add(alba.IDNumber, alba);
            people.Add(omar.IDNumber, omar);
            people.Add(israel.IDNumber, israel);
            people.Add(guillermo.IDNumber, guillermo);
            people.Add(javier.IDNumber, javier);

            Assert.AreEqual(5, people.Count);
            Assert.IsTrue(people.Contains(new KeyValuePair<string, Person>(alba.IDNumber, alba)));
            Assert.IsFalse(people.Contains(new KeyValuePair<string, Person>(bruce.IDNumber , bruce)));
            Assert.IsFalse(people.Contains(new KeyValuePair<string, Person>(alba.IDNumber, bruce)));
            Assert.IsFalse(people.Contains(new KeyValuePair<string, Person>(bruce.IDNumber, alba)));

            Assert.AreEqual(5, people.Count);
            Assert.IsTrue(people.ContainsKey(alba.IDNumber));
            Assert.IsTrue(people.ContainsKey("1"));
            Assert.IsTrue(people.ContainsKey(omar.IDNumber));
            Assert.IsTrue(people.ContainsKey("2"));
            Assert.IsTrue(people.ContainsKey(israel.IDNumber));
            Assert.IsTrue(people.ContainsKey("3"));
            Assert.IsTrue(people.ContainsKey(guillermo.IDNumber));
            Assert.IsTrue(people.ContainsKey("4"));
            Assert.IsTrue(people.ContainsKey(javier.IDNumber));
            Assert.IsTrue(people.ContainsKey("5"));
            Assert.IsFalse(people.ContainsKey(bruce.IDNumber));
            Assert.IsFalse(people.ContainsKey("6"));
            Assert.AreEqual(5, people.Count);
        }

        /// <summary>
        /// Test RemoveTest
        /// </summary>
        [TestMethod]
        public void RemoveTest()
        {
            IDictionary<string, Person> people = new Dictionary<string, Person>();
            people.Add(alba.IDNumber, alba);
            people.Add(omar.IDNumber, omar);
            people.Add(israel.IDNumber, israel);
            people.Add(guillermo.IDNumber, guillermo);
            people.Add(javier.IDNumber, javier);

            Assert.AreEqual(5, people.Count);
            Assert.IsTrue(people.Remove(javier.IDNumber));
            Assert.AreEqual(4, people.Count);
            Assert.IsFalse(people.Remove(javier.IDNumber));
            Assert.IsTrue(people.Remove(guillermo.IDNumber));
            Assert.AreEqual(3, people.Count);
            Assert.IsFalse(people.Remove(guillermo.IDNumber));
            Assert.IsTrue(people.Remove(israel.IDNumber));
            Assert.AreEqual(2, people.Count);
            Assert.IsFalse(people.Remove(israel.IDNumber));
            Assert.IsTrue(people.Remove(omar.IDNumber));
            Assert.AreEqual(1, people.Count);
            Assert.IsFalse(people.Remove(omar.IDNumber));
            Assert.IsTrue(people.Remove(alba.IDNumber));
            Assert.AreEqual(0, people.Count);
            Assert.IsFalse(people.Remove(alba.IDNumber));
            Assert.IsFalse(people.Remove(bruce.IDNumber));
        }

        /// <summary>
        /// Test ForeachTest
        /// </summary>
        [TestMethod]
        public void ForeachTest()
        {
            IDictionary<string, Person> people = new Dictionary<string, Person>();
            people.Add(alba.IDNumber, alba);
            people.Add(omar.IDNumber, omar);
            people.Add(israel.IDNumber, israel);
            people.Add(guillermo.IDNumber, guillermo);
            people.Add(javier.IDNumber, javier);

            Person[] peopleArray = new Person[people.Count];
            peopleArray[0] = alba;
            peopleArray[1] = omar;
            peopleArray[2] = israel;
            peopleArray[3] = guillermo;
            peopleArray[4] = javier;

            int idNumberCounter = 1, index = 0;
            foreach (KeyValuePair<string, Person> peopleIDPerson in people) // foreach (var peopleIDPerson in people)
            {
                Assert.AreEqual(idNumberCounter.ToString(), peopleIDPerson.Key);
                Assert.AreEqual(peopleArray[index], peopleIDPerson.Value);
                idNumberCounter++;
                index++;
            }
        }
    }
}
