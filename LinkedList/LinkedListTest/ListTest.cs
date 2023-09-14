using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AuxClasses;

namespace LinkedList
{
    /// <summary>
    /// Clase ListTest
    /// Clase de pruebas para la lista enlazada
    /// </summary>
    [TestClass]
    public class ListTest
    {
        //TESTS DE STRING:
        /// <summary>
        /// Test StringAddTest
        /// </summary>
        [TestMethod]
        public void StringAddTest()
        {
            List<string> list = new List<string>();
            list.Add("Hola");
            list.Add("esto");
            list.Add("es");
            list.Add("una");
            list.Add("prueba");
            Assert.AreEqual((uint)5, list.NumberOfElements);
            Assert.AreEqual("[Hola - esto - es - una - prueba - ]", list.ToString());
        }

        /// <summary>
        /// Test StringRemoveTest
        /// </summary>
        [TestMethod]
        public void StringRemoveTest()
        {
            List<string> list = new List<string>();
            list.Add("Hola");
            list.Add("esto");
            list.Add("es");
            list.Add("una");
            list.Add("prueba");
            Assert.IsTrue(list.Remove("Hola"));
            Assert.IsTrue(list.Remove("es"));
            Assert.IsTrue(list.Remove("prueba"));
            Assert.IsFalse(list.Remove("Hola"));
            Assert.AreEqual((uint)2, list.NumberOfElements);
            Assert.AreEqual("[esto - una - ]", list.ToString());
        }

        /// <summary>
        /// Test StringGetElementTest
        /// </summary>
        [TestMethod]
        public void StringGetElementTest()
        {
            List<string> list = new List<string>();
            list.Add("Hola");
            list.Add("esto");
            list.Add("es");
            list.Add("una");
            list.Add("prueba");
            Assert.AreEqual("Hola", list.GetElement(0));
            Assert.AreEqual("prueba", list.GetElement(4));
            Assert.AreEqual((uint)5, list.NumberOfElements);
            Assert.AreEqual("[Hola - esto - es - una - prueba - ]", list.ToString());
        }

        /// <summary>
        /// Test StringGeneralTest
        /// </summary>
        [TestMethod]
        public void StringGeneralTest()
        {
            List<string> list = new List<string>();
            list.Add("Hola");
            list.Add("esto");
            list.Add("es");
            list.Add("una");
            list.Add("prueba");
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual((uint)5, list.NumberOfElements);
            Assert.AreEqual("Hola", list.GetElement(0));
            Assert.AreEqual("prueba", list.GetElement(4));
            Assert.IsTrue(list.Contains("Hola"));
            Assert.IsTrue(list.Remove("Hola"));
            Assert.IsFalse(list.Contains("Hola"));
            Assert.IsTrue(list.Remove("es"));
            Assert.IsTrue(list.Remove("prueba"));
            list.SetElement(0, "Hola");
            list.SetElement(1, "adiós");
            Assert.IsTrue(list.Contains("Hola"));
            Assert.AreEqual((uint)2, list.NumberOfElements);
            Assert.AreEqual("[Hola - adiós - ]", list.ToString());
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual((uint)0, list.NumberOfElements);
            Assert.AreEqual("[]", list.ToString());
        }

        //TESTS DE PERSON:
        /// <summary>
        /// Test PersonAddTest
        /// </summary>
        [TestMethod]
        public void PersonAddTest()
        {
            Person alba = new Person("Alba", "Francos", "1");
            Person omar = new Person("Omar", "Teixeira", "2");
            Person israel = new Person("Israel", "Solís", "3");
            Person guillermo = new Person("Guillermo", "Pulido", "4");

            List<Person> list = new List<Person>();            
            list.Add(alba);
            list.Add(omar);
            list.Add(israel);
            list.Add(guillermo);            
            Assert.AreEqual((uint)4, list.NumberOfElements);
            Assert.AreEqual("[Alba Francos, with 1 ID number - Omar Teixeira, with 2 ID number - " +
                "Israel Solís, with 3 ID number - Guillermo Pulido, with 4 ID number - ]", list.ToString());
        }

        /// <summary>
        /// Test PersonRemoveTest
        /// </summary>
        [TestMethod]
        public void PersonRemoveTest()
        {
            Person alba = new Person("Alba", "Francos", "1");
            Person omar = new Person("Omar", "Teixeira", "2");
            Person israel = new Person("Israel", "Solís", "3");
            Person guillermo = new Person("Guillermo", "Pulido", "4");

            List<Person> list = new List<Person>();
            list.Add(alba);
            list.Add(omar);
            list.Add(israel);
            list.Add(guillermo);
            Assert.AreEqual((uint)4, list.NumberOfElements);
            Assert.IsTrue(list.Remove(israel));            
            Assert.IsTrue(list.Remove(guillermo));
            Assert.IsFalse(list.Remove(guillermo));
            Assert.AreEqual((uint)2, list.NumberOfElements);
            Assert.AreEqual("[Alba Francos, with 1 ID number - Omar Teixeira, with 2 ID number - ]", list.ToString());
        }

        /// <summary>
        /// Test PersonGetElementTest
        /// </summary>
        [TestMethod]
        public void PersonGetElementTest()
        {
            Person alba = new Person("Alba", "Francos", "1");
            Person omar = new Person("Omar", "Teixeira", "2");
            Person israel = new Person("Israel", "Solís", "3");
            Person guillermo = new Person("Guillermo", "Pulido", "4");

            List<Person> list = new List<Person>();
            list.Add(alba);
            list.Add(omar);
            list.Add(israel);
            list.Add(guillermo);
            Assert.AreEqual(alba, list.GetElement(0));
            Assert.AreEqual(omar, list.GetElement(1));
            Assert.AreEqual((uint)4, list.NumberOfElements);
            Assert.AreEqual("[Alba Francos, with 1 ID number - Omar Teixeira, with 2 ID number - " +
                "Israel Solís, with 3 ID number - Guillermo Pulido, with 4 ID number - ]", list.ToString());            
        }

        /// <summary>
        /// Test PersonGeneralTest
        /// </summary>
        [TestMethod]
        public void PersonGeneralTest()
        {

            Person alba = new Person("Alba", "Francos", "1");
            Person omar = new Person("Omar", "Teixeira", "2");
            Person israel = new Person("Israel", "Solís", "3");
            Person guillermo = new Person("Guillermo", "Pulido", "4");

            List<Person> list = new List<Person>();
            list.Add(alba);
            list.Add(omar);
            list.Add(israel);
            list.Add(guillermo);
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual((uint)4, list.NumberOfElements);
            Assert.AreEqual(alba, list.GetElement(0));
            Assert.AreEqual(omar, list.GetElement(1));
            Assert.IsTrue(list.Contains(alba));
            Assert.IsTrue(list.Remove(alba));
            Assert.IsFalse(list.Contains(alba));
            Assert.IsTrue(list.Remove(omar));            
            list.SetElement(0, alba);
            list.SetElement(1, omar);
            Assert.IsTrue(list.Contains(alba));
            Assert.AreEqual((uint)2, list.NumberOfElements);
            Assert.AreEqual("[Alba Francos, with 1 ID number - Omar Teixeira, with 2 ID number - ]", list.ToString());
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual((uint)0, list.NumberOfElements);
            Assert.AreEqual("[]", list.ToString());
        }

        //TESTS DE INT:
        /// <summary>
        /// Test IntAddTest
        /// </summary>
        [TestMethod]
        public void IntAddTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(8);
            list.Add(0);
            list.Add(6);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(9);
            Assert.AreEqual((uint)8, list.NumberOfElements);
            Assert.AreEqual("[1 - 8 - 0 - 6 - 2 - 0 - 1 - 9 - ]", list.ToString());
        }

        /// <summary>
        /// Test IntRemoveTest
        /// </summary>
        [TestMethod]
        public void IntRemoveTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(8);
            list.Add(0);
            list.Add(6);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(9);
            Assert.IsTrue(list.Remove(2));
            Assert.IsTrue(list.Remove(0));
            Assert.IsTrue(list.Remove(0));
            Assert.IsFalse(list.Remove(0));
            Assert.AreEqual((uint)5, list.NumberOfElements);
            Assert.AreEqual("[1 - 8 - 6 - 1 - 9 - ]", list.ToString());
        }

        /// <summary>
        /// Test IntGetElementTest
        /// </summary>
        [TestMethod]
        public void IntGetElementTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(8);
            list.Add(0);
            list.Add(6);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(9);
            Assert.AreEqual(1, list.GetElement(0));
            Assert.AreEqual(8, list.GetElement(1));
            Assert.AreEqual(0, list.GetElement(2));
            Assert.AreEqual(6, list.GetElement(3));
            Assert.AreEqual((uint)8, list.NumberOfElements);
            Assert.AreEqual("[1 - 8 - 0 - 6 - 2 - 0 - 1 - 9 - ]", list.ToString());
        }

        /// <summary>
        /// Test IntGeneralTest
        /// </summary>
        [TestMethod]
        public void IntGeneralTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(8);
            list.Add(0);
            list.Add(6);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(9);
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual((uint)8, list.NumberOfElements);
            Assert.AreEqual(1, list.GetElement(0));
            Assert.AreEqual(8, list.GetElement(1));
            Assert.AreEqual(0, list.GetElement(2));
            Assert.AreEqual(6, list.GetElement(3));
            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Remove(2));
            Assert.IsFalse(list.Contains(2));
            Assert.IsTrue(list.Remove(1));
            Assert.IsTrue(list.Remove(8));
            Assert.IsTrue(list.Remove(0));
            Assert.IsTrue(list.Remove(6));
            Assert.IsTrue(list.Remove(0));
            list.SetElement(0, 1);
            list.SetElement(1, 8);
            Assert.IsTrue(list.Contains(1));
            Assert.AreEqual((uint)2, list.NumberOfElements);
            Assert.AreEqual("[1 - 8 - ]", list.ToString());
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual((uint)0, list.NumberOfElements);
            Assert.AreEqual("[]", list.ToString());
        }

        //TESTS DE DOUBLE:
        /// <summary>
        /// Test DoubleAddTest
        /// </summary>
        [TestMethod]
        public void DoubleAddTest()
        {
            List<double> list = new List<double>();
            list.Add(1.8);
            list.Add(0.6);
            list.Add(2.019);
            Assert.AreEqual((uint)3, list.NumberOfElements);
            Assert.AreEqual("[1,8 - 0,6 - 2,019 - ]", list.ToString());            
        }

        /// <summary>
        /// Test DoubleRemoveTest
        /// </summary>
        [TestMethod]
        public void DoubleRemoveTest()
        {
            List<double> list = new List<double>();
            list.Add(1.8);
            list.Add(0.6);
            list.Add(2.019);
            Assert.IsTrue(list.Remove(2.019));
            Assert.IsTrue(list.Remove(0.6));
            Assert.IsFalse(list.Remove(0.6));
            Assert.AreEqual((uint)1, list.NumberOfElements);
            Assert.AreEqual("[1,8 - ]", list.ToString());
        }

        /// <summary>
        /// Test DoubleGetElementTest
        /// </summary>
        [TestMethod]
        public void DoubleGetElementTest()
        {
            List<double> list = new List<double>();
            list.Add(1.8);
            list.Add(0.6);
            list.Add(2.019);
            Assert.AreEqual(1.8, list.GetElement(0));
            Assert.AreEqual(0.6, list.GetElement(1));
            Assert.AreEqual((uint)3, list.NumberOfElements);
            Assert.AreEqual("[1,8 - 0,6 - 2,019 - ]", list.ToString());
        }

        /// <summary>
        /// Test DoubleGeneralTest
        /// </summary>
        [TestMethod]
        public void DoubleGeneralTest()
        {
            List<double> list = new List<double>();
            list.Add(1.8);
            list.Add(0.6);
            list.Add(2.019);
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual((uint)3, list.NumberOfElements);
            Assert.AreEqual(1.8, list.GetElement(0));
            Assert.AreEqual(0.6, list.GetElement(1));
            Assert.IsTrue(list.Contains(2.019));
            Assert.IsTrue(list.Remove(2.019));
            Assert.IsFalse(list.Contains(2.019));
            Assert.IsTrue(list.Remove(0.6));
            list.SetElement(0, 1.8);            
            Assert.IsTrue(list.Contains(1.8));
            Assert.AreEqual((uint)1, list.NumberOfElements);
            Assert.AreEqual("[1,8 - ]", list.ToString());
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual((uint)0, list.NumberOfElements);
            Assert.AreEqual("[]", list.ToString());
        }

        //TESTS DE MÉTODOS DE ORDEN SUPERIOR:
        /// <summary>
        /// Test FindNameTest
        /// </summary>
        [TestMethod]
        public void FindNameTest()
        {
            List<Person> people = Factory.CreateListOfPeople();
            //Prueba con delegate
            Predicate<Person> firstNamePredicate = delegate (Person persona) { return persona.FirstName=="Alba"; };
            Person pAlbaDelegate = people.Find(firstNamePredicate);
            //Prueba con expresión lambda
            Person pAlbaLambda = people.Find(persona => persona.FirstName=="Alba");

            Assert.AreEqual(pAlbaDelegate, pAlbaLambda);
            Assert.AreEqual(people.GetElement(0), pAlbaDelegate);
            Assert.AreEqual(people.GetElement(0), pAlbaLambda);

            Person pBruce = people.Find(persona => persona.FirstName=="Bruce");
            Assert.AreEqual(people.GetElement(8), pBruce);
        }

        /// <summary>
        /// Test FindNifTest
        /// </summary>
        [TestMethod]
        public void FindNifTest()
        {
            List<Person> people = Factory.CreateListOfPeople();
            //Prueba con delegate
            Predicate<Person> nifPredicate = delegate (Person persona) { return persona.IDNumber.EndsWith("A"); };
            Person pNifADelegate = people.Find(nifPredicate);
            //Prueba con expresión lambda
            Person pNifALambda = people.Find(persona => persona.IDNumber.EndsWith("A"));

            Assert.AreEqual(pNifADelegate, pNifALambda);
            Assert.AreEqual(people.GetElement(0), pNifADelegate);
            Assert.AreEqual(people.GetElement(0), pNifALambda);

            Person pNifR = people.Find(persona => persona.IDNumber.EndsWith("R"));
            Assert.AreEqual(people.GetElement(2), pNifR);
        }

        /// <summary>
        /// Test FindStraightTest
        /// </summary>
        [TestMethod]
        public void FindStraightTest()
        {
            List<Angle> angles = Factory.CreateListOfAngles();
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
            Assert.AreEqual(angles.GetElement(90), aStraightDDelegate);
            Assert.AreEqual(angles.GetElement(90), aStraightRDelegate);
            Assert.AreEqual(angles.GetElement(90), aStraightSDelegate);
            Assert.AreEqual(angles.GetElement(90), aStraightDLambda);
            Assert.AreEqual(angles.GetElement(90), aStraightRLambda);
            Assert.AreEqual(angles.GetElement(90), aStraightSLambda);
        }

        /// <summary>
        /// Test FindQuadrantTest
        /// </summary>
        [TestMethod]
        public void FindQuadrantTest()
        {
            List<Angle> angles = Factory.CreateListOfAngles();
            //Prueba con delegate
            Predicate<Angle> quadrant2Predicate = delegate (Angle angle) { return angle.Quadrant==2; };
            Angle aQuadrantDelegate = angles.Find(quadrant2Predicate);
            //Prueba con expresión lambda
            Angle aQuadrantLambda = angles.Find(angle => angle.Quadrant==2);

            Assert.AreEqual(aQuadrantDelegate, aQuadrantLambda);
            Assert.AreEqual(angles.GetElement(91), aQuadrantDelegate);
            Assert.AreEqual(angles.GetElement(91), aQuadrantLambda);

            Angle aQuadrant3 = angles.Find(angle => angle.Quadrant==3);
            Assert.AreEqual(angles.GetElement(181), aQuadrant3);
        }

        /// <summary>
        /// Test FilterNameTest
        /// </summary>
        [TestMethod]
        public void FilterNameTest()
        {
            List<Person> people = Factory.CreateListOfPeople();
            //Prueba con delegate
            Predicate<Person> firstNamePredicate = delegate (Person persona) { return persona.FirstName=="Alba"; };
            List<Person> lAlbaDelegate = people.Filter(firstNamePredicate);
            //Prueba con expresión lambda
            List<Person> lAlbaLambda = people.Filter(persona => persona.FirstName=="Alba");

            uint index = 0;
            foreach (Person alba in lAlbaDelegate)
            {
                Assert.AreEqual(alba, lAlbaLambda.GetElement(index));
                index++;
            }
            Assert.AreEqual(lAlbaDelegate.NumberOfElements, lAlbaLambda.NumberOfElements);
            Assert.AreEqual((uint) 2, lAlbaDelegate.NumberOfElements);
            Assert.AreEqual((uint) 2, lAlbaLambda.NumberOfElements);
            Assert.AreEqual(people.GetElement(0), lAlbaDelegate.GetElement(0));
            Assert.AreEqual(people.GetElement(11), lAlbaDelegate.GetElement(1));
            Assert.AreEqual(people.GetElement(0), lAlbaLambda.GetElement(0));
            Assert.AreEqual(people.GetElement(11), lAlbaLambda.GetElement(1));

            List<Person> lBruce = people.Filter(persona => persona.FirstName=="Bruce");
            Assert.AreEqual(people.GetElement(8), lBruce.GetElement(0));
        }

        /// <summary>
        /// Test FilterNifTest
        /// </summary>
        [TestMethod]
        public void FilterNifTest()
        {
            List<Person> people = Factory.CreateListOfPeople();
            //Prueba con delegate
            Predicate<Person> nifPredicate = delegate (Person persona) { return persona.IDNumber.EndsWith("A"); };
            List<Person> lNifADelegate = people.Filter(nifPredicate);
            //Prueba con expresión lambda
            List<Person> lNifALambda = people.Filter(persona => persona.IDNumber.EndsWith("A"));

            uint index = 0;
            foreach (Person nifA in lNifADelegate)
            {
                Assert.AreEqual(nifA, lNifALambda.GetElement(index));
                index++;
            }
            Assert.AreEqual(lNifADelegate.NumberOfElements, lNifALambda.NumberOfElements);
            Assert.AreEqual((uint) 2, lNifADelegate.NumberOfElements);
            Assert.AreEqual((uint) 2, lNifADelegate.NumberOfElements);
            Assert.AreEqual(people.GetElement(0), lNifADelegate.GetElement(0));
            Assert.AreEqual(people.GetElement(3), lNifADelegate.GetElement(1));
            Assert.AreEqual(people.GetElement(0), lNifALambda.GetElement(0));
            Assert.AreEqual(people.GetElement(3), lNifALambda.GetElement(1));

            List<Person> lNifR = people.Filter(persona => persona.IDNumber.EndsWith("R"));
            Assert.AreEqual(people.GetElement(2), lNifR.GetElement(0));
        }

        /// <summary>
        /// Test FilterStraightTest
        /// </summary>
        [TestMethod]
        public void FilterStraightTest()
        {
            List<Angle> angles = Factory.CreateListOfAngles();
            //Prueba con delegate
            Predicate<Angle> straightPredicateDegrees = delegate (Angle angle) { return angle.Degrees==90; };
            Predicate<Angle> straightPredicateRadians = delegate (Angle angle) { return angle.Radians==(Math.PI/2); };
            Predicate<Angle> straightPredicateSine = delegate (Angle angle) { return angle.Sine()==1; };
            List<Angle> lStraightDDelegate = angles.Filter(straightPredicateDegrees);
            List<Angle> lStraightRDelegate = angles.Filter(straightPredicateRadians);
            List<Angle> lStraightSDelegate = angles.Filter(straightPredicateSine);
            //Prueba con expresión lambda
            List<Angle> lStraightDLambda = angles.Filter(angle => angle.Degrees==90);
            List<Angle> lStraightRLambda = angles.Filter(angle => angle.Radians==(Math.PI/2));
            List<Angle> lStraightSLambda = angles.Filter(angle => angle.Sine()==1);

            uint index = 0;
            foreach (Angle angle in lStraightDDelegate)
            {
                Assert.AreEqual(angle, lStraightDLambda.GetElement(index));
                index++;
            }
            index=0;
            foreach (Angle angle in lStraightRDelegate)
            {
                Assert.AreEqual(angle, lStraightRLambda.GetElement(index));
                index++;
            }
            index=0;
            foreach (Angle angle in lStraightSDelegate)
            {
                Assert.AreEqual(angle, lStraightSLambda.GetElement(index));
                index++;
            }
        }

        /// <summary>
        /// Test FilterQuadrantTest
        /// </summary>
        [TestMethod]
        public void FilterQuadrantTest()
        {
            List<Angle> angles = Factory.CreateListOfAngles();
            //Prueba con delegate
            Predicate<Angle> quadrant2Predicate = delegate (Angle angle) { return angle.Quadrant==2; };
            List<Angle> lQuadrantDelegate = angles.Filter(quadrant2Predicate);
            //Prueba con expresión lambda
            List<Angle> lQuadrantLambda = angles.Filter(angle => angle.Quadrant==2);

            uint index = 0;
            foreach (Angle angle in lQuadrantDelegate)
            {
                Assert.AreEqual(angle, lQuadrantLambda.GetElement(index));
                index++;
            }
            index = 91;
            foreach (Angle angle in lQuadrantDelegate)
            {
                Assert.AreEqual(angle, angles.GetElement(index));
                index++;
            }
            index = 91;
            foreach (Angle angle in lQuadrantLambda)
            {
                Assert.AreEqual(angle, angles.GetElement(index));
                index++;
            }

            List<Angle> lQuadrant3 = angles.Filter(angle => angle.Quadrant==3);
            index = 181;
            foreach (Angle angle in lQuadrant3)
            {
                Assert.AreEqual(angle, angles.GetElement(index));
                index++;
            }
        }

        /// <summary>
        /// Test ReduceTotalDegreesTest
        /// </summary>
        [TestMethod]
        public void ReduceTotalDegreesTest()
        {
            List<Angle> angles = Factory.CreateListOfAngles();
            float totalDegreesReduce = angles.Reduce<float>((acum, value) => acum + value.Degrees, 0);

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
            List<Angle> angles = Factory.CreateListOfAngles();
            double maxSineComplex = angles.Reduce<double>((acum, value) =>
            {
                double sine = acum;
                if (value.Sine() > sine)
                {
                    sine = value.Sine();
                }
                return sine;
            });
            double maxSineSingle = angles.Reduce<double>((acum, value) => value.Sine() > acum ? value.Sine() : acum);
            Assert.AreEqual(1, maxSineComplex);
            Assert.AreEqual(1, maxSineSingle);
        }

        /// <summary>
        /// Test ReduceDictionaryTest
        /// </summary>
        [TestMethod]
        public void ReduceDictionaryTest()
        {
            List<Person> people = Factory.CreateListOfPeople();
            IDictionary<string, int> peopleCountByName = people.Reduce<Dictionary<string, int>>((acum, value) =>
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
            List<Person> people = Factory.CreateListOfPeople();
            List<string> peopleFullName = people.Map(person => $"{person.FirstName} {person.Surname}");
            Assert.AreEqual((uint) 12, peopleFullName.NumberOfElements);
            uint counter = 0;
            foreach (string personFN in peopleFullName)
            {
                Assert.AreEqual($"{people.GetElement(counter).FirstName} {people.GetElement(counter).Surname}", personFN);
                counter++;
            }
        }

        /// <summary>
        /// Test MapQuadrantTest
        /// </summary>
        [TestMethod]
        public void MapQuadrantTest()
        {
            List<Angle> angles = Factory.CreateListOfAngles();
            List<int> quadrantsList = angles.Map(angle => angle.Quadrant);
            Assert.AreEqual((uint) 361, quadrantsList.NumberOfElements);
            Assert.AreEqual(1, quadrantsList.GetElement(0));
            Assert.AreEqual(1, quadrantsList.GetElement(90));
            Assert.AreEqual(2, quadrantsList.GetElement(91));
            Assert.AreEqual(2, quadrantsList.GetElement(180));
            Assert.AreEqual(3, quadrantsList.GetElement(181));
            Assert.AreEqual(3, quadrantsList.GetElement(270));
            Assert.AreEqual(4, quadrantsList.GetElement(271));
            Assert.AreEqual(4, quadrantsList.GetElement(360));

            //Pruebas de todos los cuadrantes
            int counter = 0;
            foreach (int angleQuadrant in quadrantsList)
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
            List<Person> people = Factory.CreateListOfPeople();
            List<Person> peopleList = people.Reduce<List<Person>>((acum, value) =>
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
                }
                else
                {
                    Assert.AreEqual("18/06/2019", person.IDNumber);
                }
            }
            Assert.AreEqual(peopleList.GetElement(0), people.GetElement(0));
            Assert.AreEqual(peopleList.GetElement(1), people.GetElement(1));
            Assert.AreEqual(peopleList.GetElement(10), people.GetElement(10));
            Assert.AreEqual(peopleList.GetElement(11), people.GetElement(11));
        }

        //TESTS DE EXCEPCIONES:
        /// <summary>
        /// Test ConstructorNullTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorNullTest()
        {
            new List<int>(null);
        }       

        /// <summary>
        /// Test AddByIndexOutOfIndexTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddByIndexOutOfIndexTest()
        {
            Person alba = new Person("Alba", "Francos", "1");
            List<Person> list = new List<Person>();
            list.Add(alba);
            list.AddByIndex(9, new Person("Omar", "Teieira", "2"));
        }

        /// <summary>
        /// Test SetElementOutOfIndexTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetElementOutOfIndexTest()
        {
            Person alba = new Person("Alba", "Francos", "1");
            List<Person> list = new List<Person>();
            list.Add(alba);
            list.SetElement(9, new Person("Omar", "Teieira", "2"));
        }

        /// <summary>
        /// Test RemoveIsEmptyTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveIsEmptyTest()
        {

            Person alba = new Person("Alba", "Francos", "1");
            List<Person> list = new List<Person>();
            list.Remove(alba);
        }

        /// <summary>
        /// Test IndexOfIsEmptyTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IndexOfIsEmptyTest()
        {

            Person alba = new Person("Alba", "Francos", "1");
            List<Person> list = new List<Person>();
            list.IndexOf(alba);
        }

        //TEST DE ITERADORES
        /// <summary>
        /// Test IteratorIntTest
        /// </summary>
        [TestMethod]
        public void IteratorIntTest()
        {
            List<int> list = new List<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            int counter = 0;
            foreach (int i in list)
            {
                Assert.AreEqual(counter, i);
                counter++;
            }
        }

        /// <summary>
        /// Test IteratorPersonTest
        /// </summary>
        [TestMethod]
        public void IteratorPersonTest()
        {
            Person alba = new Person("Alba", "Francos", "1");
            Person omar = new Person("Omar", "Teixeira", "2");
            Person israel = new Person("Israel", "Solís", "3");
            Person guillermo = new Person("Guillermo", "Pulido", "4");

            List<Person> list = new List<Person>();
            list.Add(alba);
            list.Add(omar);
            list.Add(israel);
            list.Add(guillermo);

            Person[] array = new Person[list.NumberOfElements];
            array[0] = alba;
            array[1] = omar;
            array[2] = israel;
            array[3] = guillermo;

            int counter = 0;
            foreach (Person p in list)
            {
                Assert.AreEqual(array[counter], p);
                counter++;
            }
        }

        /// <summary>
        /// Test IteratorConstructorTest
        /// </summary>
        [TestMethod]
        public void IteratorConstructorTest()
        {
            List<int> auxList = new List<int>();
            auxList.Add(1);
            auxList.Add(2);
            auxList.Add(3);
            auxList.Add(4);

            List<int> list = new List<int>(auxList);
            uint index = 0;
            foreach (int item in list)
            {
                Assert.AreEqual(item, auxList.GetElement(index));
                index++; ;
            }
        }
    }
}
