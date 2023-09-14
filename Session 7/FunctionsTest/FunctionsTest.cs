using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TPP.Laboratory.Functional.Lab07
{
    /// <summary>
    /// Clase FunctionsTest
    /// </summary>
    [TestClass]
    public class FunctionsTest
    {
        /// <summary>
        /// Atributo people
        /// </summary>
        private Person[] people;
        /// <summary>
        /// Atributo angles
        /// </summary>
        private Angle[] angles;

        /// <summary>
        /// Método TestInitialize
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            people = Factory.CreatePeople();
            angles = Factory.CreateAngles();
        }

        //TESTS BASE:
        /// <summary>
        /// Test FindNameTest
        /// </summary>
        [TestMethod]
        public void FindNameTest()
        {   
            //Prueba con delegate
            Predicate<Person> firstNamePredicate = delegate(Person persona) { return persona.FirstName=="Alba"; };
            Person pAlbaDelegate = people.Find(firstNamePredicate);
            //Prueba con expresión lambda
            Person pAlbaLambda = people.Find(persona => persona.FirstName=="Alba");

            Assert.AreEqual(pAlbaDelegate, pAlbaLambda);
            Assert.AreEqual(people[0], pAlbaDelegate);
            Assert.AreEqual(people[0], pAlbaLambda);

            Person pBruce = people.Find(persona => persona.FirstName=="Bruce");
            Assert.AreEqual(people[8], pBruce);
        }

        /// <summary>
        /// Test FindNifTest
        /// </summary>
        [TestMethod]
        public void FindNifTest()
        {
            //Prueba con delegate
            Predicate<Person> nifPredicate = delegate (Person persona) { return persona.IDNumber.EndsWith("A"); };
            Person pNifADelegate = people.Find(nifPredicate);
            //Prueba con expresión lambda
            Person pNifALambda = people.Find(persona => persona.IDNumber.EndsWith("A"));

            Assert.AreEqual(pNifADelegate, pNifALambda);
            Assert.AreEqual(people[0], pNifADelegate);
            Assert.AreEqual(people[0], pNifALambda);

            Person pNifR = people.Find(persona => persona.IDNumber.EndsWith("R"));
            Assert.AreEqual(people[2], pNifR);
        }

        /// <summary>
        /// Test FindStraightTest
        /// </summary>
        [TestMethod]
        public void FindStraightTest()
        {
            //Prueba con delegate
            Predicate<Angle> straightPredicateDegrees = delegate (Angle angle) { return angle.Degrees==90; };
            Predicate<Angle> straightPredicateRadians = delegate (Angle angle) { return angle.Radians==(Math.PI/2); };
            Predicate<Angle> straightPredicateSine = delegate (Angle angle) { return angle.Sine()==1; };
            Angle aStraightDDelegate = angles.Find(straightPredicateDegrees);
            Angle aStraightRDelegate = angles.Find(straightPredicateRadians);
            Angle aStraightSDelegate = angles.Find(straightPredicateSine);
            //Prueba con expresión lambda
            Angle aStraightDLambda = angles.Find(angle => angle.Degrees==90);
            Angle aStraightRLambda = angles.Find(angle => angle.Radians==(Math.PI/2));
            Angle aStraightSLambda = angles.Find(angle => angle.Sine()==1);

            Assert.AreEqual(aStraightDDelegate, aStraightDLambda);
            Assert.AreEqual(aStraightRDelegate, aStraightRLambda);
            Assert.AreEqual(aStraightSDelegate, aStraightSLambda);
            Assert.AreEqual(angles[90], aStraightDDelegate);
            Assert.AreEqual(angles[90], aStraightRDelegate);
            Assert.AreEqual(angles[90], aStraightSDelegate);
            Assert.AreEqual(angles[90], aStraightDLambda);
            Assert.AreEqual(angles[90], aStraightRLambda);
            Assert.AreEqual(angles[90], aStraightSLambda);
        }

        /// <summary>
        /// Test FindQuadrantTest
        /// </summary>
        [TestMethod]
        public void FindQuadrantTest()
        {
            //Prueba con delegate
            Predicate<Angle> quadrant2Predicate = delegate (Angle angle) { return angle.Quadrant==2; };
            Angle aQuadrantDelegate = angles.Find(quadrant2Predicate);
            //Prueba con expresión lambda
            Angle aQuadrantLambda = angles.Find(angle => angle.Quadrant==2);

            Assert.AreEqual(aQuadrantDelegate, aQuadrantLambda);
            Assert.AreEqual(angles[91], aQuadrantDelegate);
            Assert.AreEqual(angles[91], aQuadrantLambda);

            Angle aQuadrant3 = angles.Find(angle => angle.Quadrant==3);
            Assert.AreEqual(angles[181], aQuadrant3);
        }

        /// <summary>
        /// Test FilterNameTest
        /// </summary>
        [TestMethod]
        public void FilterNameTest()
        {
            //Prueba con delegate
            Predicate<Person> firstNamePredicate = delegate (Person persona) { return persona.FirstName=="Alba"; };
            Person[] lAlbaDelegate = people.Filter(firstNamePredicate).ToArray();
            //Prueba con expresión lambda
            Person[] lAlbaLambda = people.Filter(persona => persona.FirstName=="Alba").ToArray();

            int index = 0;
            foreach (Person alba in lAlbaDelegate)
            {
                Assert.AreEqual(alba, lAlbaLambda[index]);
                index++;
            }            
            Assert.AreEqual(lAlbaDelegate.Length, lAlbaLambda.Length);
            Assert.AreEqual(2, lAlbaDelegate.Length);
            Assert.AreEqual(2, lAlbaLambda.Length);
            Assert.AreEqual(people[0], lAlbaDelegate[0]);
            Assert.AreEqual(people[11], lAlbaDelegate[1]);
            Assert.AreEqual(people[0], lAlbaLambda[0]);
            Assert.AreEqual(people[11], lAlbaLambda[1]);

            Person[] lBruce = people.Filter(persona => persona.FirstName=="Bruce").ToArray();
            Assert.AreEqual(people[8], lBruce[0]);
        }

        /// <summary>
        /// Test FilterNifTest
        /// </summary>
        [TestMethod]
        public void FilterNifTest()
        {
            //Prueba con delegate
            Predicate<Person> nifPredicate = delegate (Person persona) { return persona.IDNumber.EndsWith("A"); };
            Person[] lNifADelegate = people.Filter(nifPredicate).ToArray();
            //Prueba con expresión lambda
            Person[] lNifALambda = people.Filter(persona => persona.IDNumber.EndsWith("A")).ToArray();

            int index = 0;
            foreach (Person nifA in lNifADelegate)
            {
                Assert.AreEqual(nifA, lNifALambda[index]);
                index++;
            }
            Assert.AreEqual(lNifADelegate.Length, lNifALambda.Length);
            Assert.AreEqual(2, lNifADelegate.Length);
            Assert.AreEqual(2, lNifADelegate.Length);
            Assert.AreEqual(people[0], lNifADelegate[0]);
            Assert.AreEqual(people[3], lNifADelegate[1]);
            Assert.AreEqual(people[0], lNifALambda[0]);
            Assert.AreEqual(people[3], lNifALambda[1]);

            Person[] lNifR = people.Filter(persona => persona.IDNumber.EndsWith("R")).ToArray();
            Assert.AreEqual(people[2], lNifR[0]);
        }

        /// <summary>
        /// Test FilterStraightTest
        /// </summary>
        [TestMethod]
        public void FilterStraightTest()
        {
            //Prueba con delegate
            Predicate<Angle> straightPredicateDegrees = delegate (Angle angle) { return angle.Degrees==90; };
            Predicate<Angle> straightPredicateRadians = delegate (Angle angle) { return angle.Radians==(Math.PI/2); };
            Predicate<Angle> straightPredicateSine = delegate (Angle angle) { return angle.Sine()==1; };
            Angle[] lStraightDDelegate = angles.Filter(straightPredicateDegrees).ToArray();
            Angle[] lStraightRDelegate = angles.Filter(straightPredicateRadians).ToArray();
            Angle[] lStraightSDelegate = angles.Filter(straightPredicateSine).ToArray();
            //Prueba con expresión lambda
            Angle[] lStraightDLambda = angles.Filter(angle => angle.Degrees==90).ToArray();
            Angle[] lStraightRLambda = angles.Filter(angle => angle.Radians==(Math.PI/2)).ToArray();
            Angle[] lStraightSLambda = angles.Filter(angle => angle.Sine()==1).ToArray();

            int index = 0;
            foreach (Angle angle in lStraightDDelegate)
            {
                Assert.AreEqual(angle, lStraightDLambda[index]);
                index++;
            }
            index=0;
            foreach (Angle angle in lStraightRDelegate)
            {
                Assert.AreEqual(angle, lStraightRLambda[index]);
                index++;
            }
            index=0;
            foreach (Angle angle in lStraightSDelegate)
            {
                Assert.AreEqual(angle, lStraightSLambda[index]);
                index++;
            }
        }

        /// <summary>
        /// Test FilterQuadrantTest
        /// </summary>
        [TestMethod]
        public void FilterQuadrantTest()
        {
            //Prueba con delegate
            Predicate<Angle> quadrant2Predicate = delegate (Angle angle) { return angle.Quadrant==2; };
            Angle[] lQuadrantDelegate = angles.Filter(quadrant2Predicate).ToArray();
            //Prueba con expresión lambda
            Angle[] lQuadrantLambda = angles.Filter(angle => angle.Quadrant==2).ToArray();

            int index = 0;
            foreach (Angle angle in lQuadrantDelegate)
            {
                Assert.AreEqual(angle, lQuadrantLambda[index]);
                index++;
            }
            index = 91;
            foreach (Angle angle in lQuadrantDelegate)
            {
                Assert.AreEqual(angle, angles[index]);
                index++;
            }
            index = 91;
            foreach (Angle angle in lQuadrantLambda)
            {
                Assert.AreEqual(angle, angles[index]);
                index++;
            }              

            Angle[] lQuadrant3 = angles.Filter(angle => angle.Quadrant==3).ToArray();
            index = 181;
            foreach (Angle angle in lQuadrant3)
            {
                Assert.AreEqual(angle, angles[index]);
                index++;
            }
        }

        /// <summary>
        /// Test ReduceTotalDegreesTest
        /// </summary>
        [TestMethod]
        public void ReduceTotalDegreesTest()
        {
            float totalDegreesReduce = angles.Reduce<Angle, float>((acum, value) => acum + value.Degrees, 0);

            float totalDegreesIter = 0;
            foreach (Angle angle in angles)
            {
                totalDegreesIter+=angle.Degrees;
            }
            Assert.AreEqual(totalDegreesIter, totalDegreesReduce);
            Assert.AreEqual(64980, totalDegreesReduce);
        }

        /// <summary>
        /// Test ReduceMaxSineTest
        /// </summary>
        [TestMethod]
        public void ReduceMaxSineTest()
        {
            double maxSineComplex = angles.Reduce<Angle, double>((acum, value) =>
            {
                double sine = acum;
                if (value.Sine() > sine)
                {
                    sine = value.Sine();
                }
                return sine;
            });
            double maxSineSingle = angles.Reduce<Angle, double>((acum, value) => value.Sine() > acum ? value.Sine() : acum);
            Assert.AreEqual(1, maxSineComplex);
            Assert.AreEqual(1, maxSineSingle);
        }

        /// <summary>
        /// Test ReduceDictionaryTest
        /// </summary>
        [TestMethod]
        public void ReduceDictionaryTest()
        {
            IDictionary<string, int> peopleCountByName = people.Reduce<Person, Dictionary<string, int>>((acum, value) =>
            {
                if (!acum.ContainsKey(value.FirstName))
                {
                    acum[value.FirstName]=1;
                }
                else
                {
                    acum[value.FirstName]++;
                }
                return acum;
            }, new Dictionary<string, int>());
            Assert.AreEqual(1, peopleCountByName["Bruce"]);
            Assert.AreEqual(1, peopleCountByName["Selina"]);
            Assert.AreEqual(2, peopleCountByName["Alba"]);
            Assert.AreEqual(2, peopleCountByName["Omar"]);
        }

        /// <summary>
        /// Test MapFullNameTest
        /// </summary>
        [TestMethod]
        public void MapFullNameTest()
        {
            string[] peopleFullName = people.Map(person => $"{person.FirstName} {person.Surname}").ToArray();
            Assert.AreEqual(12, peopleFullName.Length);
            int counter = 0;
            foreach (string personFN in peopleFullName)
            {
                Assert.AreEqual($"{people[counter].FirstName} {people[counter].Surname}", personFN);
                counter++;
            }
        }

        /// <summary>
        /// Test MapQuadrantTest
        /// </summary>
        [TestMethod]
        public void MapQuadrantTest()
        {
            int[] quadrantsList = angles.Map(angle => angle.Quadrant).ToArray();
            Assert.AreEqual(361, quadrantsList.Length);
            Assert.AreEqual(1, quadrantsList[0]);            
            Assert.AreEqual(1, quadrantsList[90]);
            Assert.AreEqual(2, quadrantsList[91]);            
            Assert.AreEqual(2, quadrantsList[180]);
            Assert.AreEqual(3, quadrantsList[181]);            
            Assert.AreEqual(3, quadrantsList[270]);
            Assert.AreEqual(4, quadrantsList[271]);            
            Assert.AreEqual(4, quadrantsList[360]);

            //Pruebas de todos los cuadrantes
            int counter = 0;
            foreach(int angleQuadrant in quadrantsList)
            {
                //Primer cuadrante
                if (counter <=90)
                {
                    Assert.AreEqual(1, angleQuadrant);
                }
                //Segundo cuadrante
                else if (counter <= 180)
                {
                    Assert.AreEqual(2, angleQuadrant);
                }
                //Tercer cuadrante
                else if (counter <= 270)
                {
                    Assert.AreEqual(3, angleQuadrant);
                }
                //Cuarto cuadrante
                else
                {
                    Assert.AreEqual(4, angleQuadrant);
                }
                counter++;
            }
        }

        //TEST EXTRAS DE PRUEBAS
        /// <summary>
        /// Test ReduceListTest
        /// </summary>
        [TestMethod]
        public void ReduceListTest()
        {
            IList<Person> peopleList = (IList<Person>) people.Reduce<Person, List<Person>>((acum, value) =>
            {
                if (!value.FirstName.Equals("Alba") && !value.FirstName.Equals("Omar"))
                {
                    value.IDNumber="REMOVED";
                }
                else
                {
                    value.IDNumber="18/06/2019";                    
                }
                acum.Add(value);
                return acum;
            }, new List<Person>());
            foreach (Person person in peopleList)
            {
                if (!person.FirstName.Equals("Alba") && !person.FirstName.Equals("Omar"))
                {
                    Assert.AreEqual("REMOVED", person.IDNumber);
                } else
                {
                    Assert.AreEqual("18/06/2019", person.IDNumber);
                }
            }
            Assert.AreEqual(peopleList[0], people[0]);
            Assert.AreEqual(peopleList[1], people[1]);
            Assert.AreEqual(peopleList[10], people[10]);
            Assert.AreEqual(peopleList[11], people[11]);
        }
    }
}
